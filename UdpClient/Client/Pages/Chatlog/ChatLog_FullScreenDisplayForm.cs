using System.Drawing.Drawing2D;
using Texter_App.Runtime;

namespace Texter_App.Pages
{
    public partial class ChatLog_FullScreenDisplayForm : Form
    {
        public ChatLog_FullScreenDisplayForm()
        {
            InitializeComponent();

            this.Opacity = RuntimeConfigs.WindowOpacity;
            this.Show();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.ClientRectangle.IsEmpty) return;
            base.OnPaint(e);

            // Create a linear gradient brush from Magenta to Turquoise.
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                RuntimeConfigs.Gradient1,
                RuntimeConfigs.Gradient2,
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        public void DisplayFullScreenMessage(string _message, string _person, string _time)
        {
            txtArea.Text = _message;
            lblSender.Text = $"Sender: <{_person}>";
            lblTime.Text = $"At: <{_time}>";
        }

        private void ChatLog_FullScreenDisplayForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}