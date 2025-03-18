#pragma warning disable CS8618
using Sender;
using Texter_App.Pages;
using Texter_App.Util;
using Texter_App.Util.Interface;
using Texter_App.Runtime;
using Texter_App.Util.FileFormat.JSON;
using System.Drawing.Drawing2D;

namespace Receiver
{
    public partial class Landing_MainForm : Form
    {
        public static List<Contact> _IPs;

        private static bool closeEventSentFromTray = false;
        //private static bool lastNotificationIsMessage = false;

        //private static _UNUSED_ChatLog_MainForm _chatLogForm;
        public static Sender_MainForm _senderMainForm;
        public static Settings_MainForm _settingsForm;

        private static NotifyIcon _infoDisplayTray;
        private static Button _toggleServerButton;

        public Landing_MainForm()
        {
            InitializeComponent();
            FormHandler.InitiateGeneric(ref _IPs);

            // Assign some local vars to static, to expose them via static functions
            _infoDisplayTray = notifyTrayIcon;
            _toggleServerButton = btnToggleServer;

            // Forms have 0 opacity at launch to not show form creations, create->hide->Set Normal Opacity
            FormHandler.InitiateFormOnStartup(ref _senderMainForm);
            FormHandler.InitiateFormOnStartup(ref _settingsForm);

            // Lastly, run receiver
            RuntimeConfigs.ToggleServer(true);
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
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        public static void ChangeServerToggleButtonColor(bool _enable)
        {
            _toggleServerButton.BackColor = _enable ? Color.DarkSeaGreen : Color.Crimson;
            _toggleServerButton.Text = _enable ? "Listener On" : "Listener Off";
        }

        public static void AppendToChatLog(string _message, string _sender, string _receiver, bool openChatLog = RuntimeConfigs.AlwaysOpenChatLog)
        {
            _senderMainForm.AppendChat(_message, _sender, _receiver);
            if (openChatLog)
            {
                FormHandler.NotificationToForm(_senderMainForm);
            }
        }

        public static void NotifyIncomingMessage(string _message)
        {
            //lastNotificationIsMessage = true;
            _infoDisplayTray.ShowBalloonTip(3, "New Message", _message, ToolTipIcon.None);
        }
        public static void NotifyServerDebug(string _message)
        {
            //lastNotificationIsMessage = false;
            _infoDisplayTray.ShowBalloonTip(3, "Info", _message, ToolTipIcon.Info);
        }

        private void btnToggleServer_Click(object sender, EventArgs e)
        {
            RuntimeConfigs.ToggleServer();
        }

        private void Server_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeEventSentFromTray)
            {
                e.Cancel = true;
                FormHandler.FormToNotification(this);
            }
            else
            {
                if (!Prompt.Quit())
                {
                    e.Cancel = true;
                    closeEventSentFromTray = false;
                }
            }
        }
        private void context_Show_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(this);
        }

        private void context_Exit_Click(object sender, EventArgs e)
        {
            closeEventSentFromTray = true;
            this.Close();
        }


        private void Server_MainForm_Shown(object sender, EventArgs e)
        {
            FormHandler.FormToNotification(this);
            this.Opacity = RuntimeConfigs.WindowOpacity;
            notifyTrayIcon.ShowBalloonTip(3);
        }

        private void notifyTrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(_senderMainForm);
            //if (lastNotificationIsMessage)
            //{
            //    FormHandler.NotificationToForm(_senderMainForm);
            //}
            //else
            //{
            //    FormHandler.NotificationToForm(this);
            //}
        }

        private void showSenderPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(_senderMainForm);
        }

        private void btnWriteNewMessage_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(_senderMainForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(_settingsForm);
        }

        private void settingsIPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(_settingsForm);
        }

        private void notifyTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormHandler.NotificationToForm(_senderMainForm);
        }
    }
}
