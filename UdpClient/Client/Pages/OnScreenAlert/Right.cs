using System.Runtime.InteropServices;
using Texter_App.Runtime;

namespace Texter_App.Pages.OnScreenAlert
{
    public partial class Right : Form
    {
        private System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        private int currentAlpha = 0;
        private bool fadingIn = true;
        private int fadeCycleCount = 0;
        // Each full blink consists of a fade in and a fade out (2 cycles).
        private const int totalCycles = RuntimeConfigs.OnScreenAlertBlinkCount * 2;   // (fade in/out)
        private const int targetAlpha = 128; // Maximum opacity for the alert overlay.
        private const int fadeStep = RuntimeConfigs.OnScreenAlertFadeStep;     // Change in alpha per tick.

        private static Right _instance;
        private static readonly object _lock = new object();
        public static Right Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null || _instance.IsDisposed)
                    {
                        _instance = new Right();
                    }
                    return _instance;
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        private int alertWidth;
        private Right()
        {
            SetProcessDPIAware();
            InitializeComponent();
            this.Opacity = 0.8;
            // Set a key color for transparency.
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            // Ensure the form uses manual positioning.
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            // Set the form bounds to appear only as a narrow band on the right side.
            Rectangle screenBounds = Screen.PrimaryScreen.WorkingArea;
            alertWidth = screenBounds.Width / 20; // Store the alert band width.
            this.Bounds = screenBounds; // Make the form fullscreen.

            // Enable double buffering to reduce flickering.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // Configure timer for smoother fade transitions.
            fadeTimer.Interval = 25;
            fadeTimer.Tick += FadeTimer_Tick;
        }


        // Enable layered and click-through styles.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000 | 0x00000020; // WS_EX_LAYERED | WS_EX_TRANSPARENT
                return cp;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        private const int LWA_ALPHA = 0x00000002;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Set initial opacity to fully opaque (255).
            //SetLayeredWindowAttributes(this.Handle, 0, 190, LWA_ALPHA);
        }

        // Start the fade transition.
        public void TriggerAlert()
        {
            currentAlpha = 0;
            fadingIn = false;
            fadeCycleCount = 0;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (fadingIn)
            {
                currentAlpha += fadeStep;
                if (currentAlpha >= targetAlpha)
                {
                    currentAlpha = targetAlpha;
                    fadingIn = false;
                    fadeCycleCount++;
                }
            }
            else
            {
                currentAlpha -= fadeStep;
                if (currentAlpha <= 0)
                {
                    currentAlpha = 0;
                    fadingIn = true;
                    fadeCycleCount++;
                }
            }

            // Redraw the window to update the overlay.
            this.Invalidate();

            // Stop the timer after completing the desired number of fade cycles.
            if (fadeCycleCount >= totalCycles)
            {
                fadeTimer.Stop();
                this.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Clear the full form with the transparency key color so non-alert areas remain transparent.
            e.Graphics.Clear(this.TransparencyKey);

            // Define the alert band (rightmost area) where the gradient and blinking effect occur.
            Rectangle alertRect = new Rectangle(this.Width - alertWidth, 0, alertWidth, this.Height);

            // Draw the gradient in the alert band.
            using (var lgb = new System.Drawing.Drawing2D.LinearGradientBrush(
                alertRect,
                RuntimeConfigs.Gradient1,
                RuntimeConfigs.Gradient2,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(lgb, alertRect);
            }

            // When the fade timer is active, draw the blinking overlay on top.
            if (fadeTimer.Enabled)
            {
                // Draw the fade overlay only on the alert band.
                using (var overlayBrush = new SolidBrush(Color.FromArgb(currentAlpha, Color.Black)))
                {
                    e.Graphics.FillRectangle(overlayBrush, alertRect);
                }

                // Draw the arrow so its tip aligns with the far right edge of the alert band.
                int arrowSize = alertRect.Width / 3; // Adjust arrow size as needed.
                Point tip = new Point(alertRect.Right, alertRect.Height / 2);
                Point top = new Point(alertRect.Right - arrowSize, alertRect.Height / 2 - arrowSize);
                Point bottom = new Point(alertRect.Right - arrowSize, alertRect.Height / 2 + arrowSize);
                Point[] arrowPoints = new Point[] { top, bottom, tip };
                using (var arrowBrush = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillPolygon(arrowBrush, arrowPoints);
                }
            }
        }

        private void Right_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }



}
