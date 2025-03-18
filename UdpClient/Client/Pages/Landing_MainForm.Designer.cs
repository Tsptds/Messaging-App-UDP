namespace Receiver
{
    partial class Landing_MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Landing_MainForm));
            btnToggleServer = new Button();
            notifyTrayIcon = new NotifyIcon(components);
            context1 = new ContextMenuStrip(components);
            showSenderPanelToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            settingsIPsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            context_Show = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            context_Exit = new ToolStripMenuItem();
            btnWriteNewMessage = new Button();
            btnSettings = new Button();
            context1.SuspendLayout();
            SuspendLayout();
            // 
            // btnToggleServer
            // 
            btnToggleServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnToggleServer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleServer.BackColor = Color.Crimson;
            btnToggleServer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnToggleServer.Location = new Point(12, 119);
            btnToggleServer.Name = "btnToggleServer";
            btnToggleServer.Size = new Size(257, 80);
            btnToggleServer.TabIndex = 0;
            btnToggleServer.Text = "Listener Off";
            btnToggleServer.UseVisualStyleBackColor = false;
            btnToggleServer.Click += btnToggleServer_Click;
            // 
            // notifyTrayIcon
            // 
            notifyTrayIcon.BalloonTipText = "TexterApp Will Stay In Notification Area";
            notifyTrayIcon.BalloonTipTitle = "Texter App";
            notifyTrayIcon.ContextMenuStrip = context1;
            notifyTrayIcon.Icon = (Icon)resources.GetObject("notifyTrayIcon.Icon");
            notifyTrayIcon.Text = "Texter App";
            notifyTrayIcon.Visible = true;
            notifyTrayIcon.BalloonTipClicked += notifyTrayIcon_BalloonTipClicked;
            notifyTrayIcon.MouseDoubleClick += notifyTrayIcon_MouseDoubleClick;
            // 
            // context1
            // 
            context1.ImageScalingSize = new Size(20, 20);
            context1.Items.AddRange(new ToolStripItem[] { showSenderPanelToolStripMenuItem, toolStripSeparator2, settingsIPsToolStripMenuItem, toolStripSeparator3, context_Show, toolStripSeparator1, context_Exit });
            context1.Name = "contextMenuStrip1";
            context1.Size = new Size(167, 118);
            // 
            // showSenderPanelToolStripMenuItem
            // 
            showSenderPanelToolStripMenuItem.Name = "showSenderPanelToolStripMenuItem";
            showSenderPanelToolStripMenuItem.Size = new Size(166, 24);
            showSenderPanelToolStripMenuItem.Text = "Messaging";
            showSenderPanelToolStripMenuItem.Click += showSenderPanelToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(163, 6);
            // 
            // settingsIPsToolStripMenuItem
            // 
            settingsIPsToolStripMenuItem.Name = "settingsIPsToolStripMenuItem";
            settingsIPsToolStripMenuItem.Size = new Size(166, 24);
            settingsIPsToolStripMenuItem.Text = "Settings / IPs";
            settingsIPsToolStripMenuItem.Click += settingsIPsToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(163, 6);
            // 
            // context_Show
            // 
            context_Show.Name = "context_Show";
            context_Show.Size = new Size(166, 24);
            context_Show.Text = "Control Panel";
            context_Show.Click += context_Show_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(163, 6);
            // 
            // context_Exit
            // 
            context_Exit.Name = "context_Exit";
            context_Exit.Size = new Size(166, 24);
            context_Exit.Text = "Exit";
            context_Exit.Click += context_Exit_Click;
            // 
            // btnWriteNewMessage
            // 
            btnWriteNewMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnWriteNewMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnWriteNewMessage.BackColor = Color.MediumTurquoise;
            btnWriteNewMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnWriteNewMessage.Location = new Point(12, 33);
            btnWriteNewMessage.Name = "btnWriteNewMessage";
            btnWriteNewMessage.Size = new Size(540, 80);
            btnWriteNewMessage.TabIndex = 1;
            btnWriteNewMessage.Text = "Messaging";
            btnWriteNewMessage.UseVisualStyleBackColor = false;
            btnWriteNewMessage.Click += btnWriteNewMessage_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSettings.BackColor = Color.Thistle;
            btnSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSettings.Location = new Point(295, 119);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(257, 80);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings / IPs";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // Landing_MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Window;
            ClientSize = new Size(564, 249);
            Controls.Add(btnSettings);
            Controls.Add(btnWriteNewMessage);
            Controls.Add(btnToggleServer);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(586, 300);
            MinimumSize = new Size(586, 300);
            Name = "Landing_MainForm";
            Opacity = 0D;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Texter App";
            FormClosing += Server_MainForm_FormClosing;
            Shown += Server_MainForm_Shown;
            context1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnToggleServer;
        private ContextMenuStrip context1;
        private ToolStripMenuItem context_Show;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem context_Exit;
        private NotifyIcon notifyTrayIcon;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem showSenderPanelToolStripMenuItem;
        private Button btnWriteNewMessage;
        private Button btnSettings;
        private ToolStripMenuItem settingsIPsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
    }
}
