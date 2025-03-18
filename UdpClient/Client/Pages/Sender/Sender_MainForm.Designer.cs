namespace Sender
{
    partial class Sender_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sender_MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            notifyTrayIcon = new NotifyIcon(components);
            Send = new Button();
            lblCharCount = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer7 = new SplitContainer();
            btnSettings = new Button();
            btnToggleServer = new Button();
            lstContacts = new ListBox();
            lstRightClickMenu = new ContextMenuStrip(components);
            renameContactToolStripMenuItem = new ToolStripMenuItem();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            lblIp = new Label();
            chatLogBox = new DataGridView();
            messages = new DataGridViewTextBoxColumn();
            person = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            msgID = new DataGridViewTextBoxColumn();
            chatLogBoxRightClickMenu = new ContextMenuStrip(components);
            showFullMessageToolStripMenuItem = new ToolStripMenuItem();
            deleteContactsToolStripMenuItem = new ToolStripMenuItem();
            splitContainer6 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            lblAlertInfo = new Label();
            btnHeadsUpLeft = new Button();
            btnHeadsUpRight = new Button();
            splitContainer10 = new SplitContainer();
            txtArea = new RichTextBox();
            tipContacts = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.Panel1.SuspendLayout();
            splitContainer7.Panel2.SuspendLayout();
            splitContainer7.SuspendLayout();
            lstRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chatLogBox).BeginInit();
            chatLogBoxRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer10).BeginInit();
            splitContainer10.Panel1.SuspendLayout();
            splitContainer10.Panel2.SuspendLayout();
            splitContainer10.SuspendLayout();
            SuspendLayout();
            // 
            // notifyTrayIcon
            // 
            notifyTrayIcon.BalloonTipText = "TexterApp Will Stay In Notification Area";
            notifyTrayIcon.BalloonTipTitle = "Texter App - Client";
            notifyTrayIcon.Icon = (Icon)resources.GetObject("notifyTrayIcon.Icon");
            notifyTrayIcon.Text = "TexterApp - Client";
            // 
            // Send
            // 
            Send.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Send.BackColor = Color.DarkTurquoise;
            Send.Cursor = Cursors.Hand;
            Send.Dock = DockStyle.Fill;
            Send.Font = new Font("Lucida Sans Typewriter", 10.8F, FontStyle.Bold);
            Send.Location = new Point(5, 5);
            Send.Margin = new Padding(0);
            Send.Name = "Send";
            Send.Size = new Size(112, 52);
            Send.TabIndex = 3;
            Send.Text = "Send";
            Send.UseVisualStyleBackColor = false;
            Send.Click += Send_Click;
            // 
            // lblCharCount
            // 
            lblCharCount.Dock = DockStyle.Left;
            lblCharCount.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            lblCharCount.ForeColor = Color.AliceBlue;
            lblCharCount.Location = new Point(20, 5);
            lblCharCount.Name = "lblCharCount";
            lblCharCount.Padding = new Padding(0, 0, 20, 10);
            lblCharCount.Size = new Size(553, 47);
            lblCharCount.TabIndex = 9;
            lblCharCount.Text = "Placeholder Char Count";
            lblCharCount.TextAlign = ContentAlignment.BottomLeft;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(23, 51);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.LightSlateGray;
            splitContainer1.Panel1.Controls.Add(splitContainer7);
            splitContainer1.Panel1.Font = new Font("Bookman Old Style", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            splitContainer1.Panel1.ForeColor = Color.AliceBlue;
            splitContainer1.Panel1.Padding = new Padding(20);
            splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.CadetBlue;
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2MinSize = 500;
            splitContainer1.Size = new Size(1216, 599);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 13;
            // 
            // splitContainer7
            // 
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.FixedPanel = FixedPanel.Panel1;
            splitContainer7.IsSplitterFixed = true;
            splitContainer7.Location = new Point(20, 20);
            splitContainer7.Name = "splitContainer7";
            splitContainer7.Orientation = Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            splitContainer7.Panel1.Controls.Add(btnSettings);
            splitContainer7.Panel1.Controls.Add(btnToggleServer);
            splitContainer7.Panel1.Padding = new Padding(15, 20, 15, 20);
            // 
            // splitContainer7.Panel2
            // 
            splitContainer7.Panel2.Controls.Add(lstContacts);
            splitContainer7.Size = new Size(360, 559);
            splitContainer7.SplitterDistance = 95;
            splitContainer7.TabIndex = 3;
            // 
            // btnSettings
            // 
            btnSettings.AutoEllipsis = true;
            btnSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSettings.BackColor = Color.LightCyan;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Right;
            btnSettings.Font = new Font("Lucida Sans Typewriter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.Black;
            btnSettings.Location = new Point(196, 20);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(149, 55);
            btnSettings.TabIndex = 22;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnToggleServer
            // 
            btnToggleServer.AutoEllipsis = true;
            btnToggleServer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleServer.BackColor = Color.DarkSeaGreen;
            btnToggleServer.Cursor = Cursors.Hand;
            btnToggleServer.Dock = DockStyle.Left;
            btnToggleServer.Font = new Font("Lucida Sans Typewriter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToggleServer.ForeColor = Color.Black;
            btnToggleServer.Location = new Point(15, 20);
            btnToggleServer.Name = "btnToggleServer";
            btnToggleServer.Size = new Size(149, 55);
            btnToggleServer.TabIndex = 21;
            btnToggleServer.Text = "On";
            btnToggleServer.UseVisualStyleBackColor = false;
            btnToggleServer.Click += btnToggleServer_Click;
            // 
            // lstContacts
            // 
            lstContacts.BackColor = Color.Gainsboro;
            lstContacts.ContextMenuStrip = lstRightClickMenu;
            lstContacts.Dock = DockStyle.Fill;
            lstContacts.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lstContacts.FormattingEnabled = true;
            lstContacts.ItemHeight = 27;
            lstContacts.Items.AddRange(new object[] { "Placeholder Contact" });
            lstContacts.Location = new Point(0, 0);
            lstContacts.Margin = new Padding(20);
            lstContacts.Name = "lstContacts";
            lstContacts.ScrollAlwaysVisible = true;
            lstContacts.Size = new Size(360, 460);
            lstContacts.TabIndex = 2;
            lstContacts.SelectedIndexChanged += lstContacts_SelectedIndexChanged;
            // 
            // lstRightClickMenu
            // 
            lstRightClickMenu.ImageScalingSize = new Size(20, 20);
            lstRightClickMenu.Items.AddRange(new ToolStripItem[] { renameContactToolStripMenuItem });
            lstRightClickMenu.Name = "lstRightClickMenu";
            lstRightClickMenu.RenderMode = ToolStripRenderMode.System;
            lstRightClickMenu.Size = new Size(249, 28);
            // 
            // renameContactToolStripMenuItem
            // 
            renameContactToolStripMenuItem.Name = "renameContactToolStripMenuItem";
            renameContactToolStripMenuItem.Size = new Size(248, 24);
            renameContactToolStripMenuItem.Text = "Rename Selected Contact";
            renameContactToolStripMenuItem.Click += renameContactToolStripMenuItem_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.BackColor = Color.Transparent;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.Transparent;
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer6);
            splitContainer2.Size = new Size(812, 599);
            splitContainer2.SplitterDistance = 472;
            splitContainer2.TabIndex = 13;
            // 
            // splitContainer3
            // 
            splitContainer3.BackColor = Color.Transparent;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(lblIp);
            splitContainer3.Panel1.Padding = new Padding(20, 10, 20, 10);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(chatLogBox);
            splitContainer3.Panel2.Padding = new Padding(20);
            splitContainer3.Size = new Size(812, 472);
            splitContainer3.SplitterDistance = 101;
            splitContainer3.TabIndex = 0;
            // 
            // lblIp
            // 
            lblIp.AutoEllipsis = true;
            lblIp.BackColor = Color.AliceBlue;
            lblIp.Dock = DockStyle.Top;
            lblIp.FlatStyle = FlatStyle.Popup;
            lblIp.Font = new Font("Bookman Old Style", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblIp.Location = new Point(20, 10);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(772, 28);
            lblIp.TabIndex = 17;
            lblIp.TextAlign = ContentAlignment.MiddleCenter;
            lblIp.MouseHover += lblIp_MouseHover;
            // 
            // chatLogBox
            // 
            chatLogBox.AllowUserToAddRows = false;
            chatLogBox.AllowUserToDeleteRows = false;
            chatLogBox.AllowUserToResizeColumns = false;
            chatLogBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            chatLogBox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            chatLogBox.BackgroundColor = Color.AliceBlue;
            chatLogBox.BorderStyle = BorderStyle.Fixed3D;
            chatLogBox.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            chatLogBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            chatLogBox.Columns.AddRange(new DataGridViewColumn[] { messages, person, time, msgID });
            chatLogBox.ContextMenuStrip = chatLogBoxRightClickMenu;
            chatLogBox.Dock = DockStyle.Fill;
            chatLogBox.GridColor = Color.DarkTurquoise;
            chatLogBox.Location = new Point(20, 20);
            chatLogBox.Name = "chatLogBox";
            chatLogBox.ReadOnly = true;
            chatLogBox.RowHeadersVisible = false;
            chatLogBox.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = Color.AliceBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            chatLogBox.RowsDefaultCellStyle = dataGridViewCellStyle1;
            chatLogBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            chatLogBox.ShowCellErrors = false;
            chatLogBox.ShowCellToolTips = false;
            chatLogBox.ShowEditingIcon = false;
            chatLogBox.Size = new Size(772, 327);
            chatLogBox.StandardTab = true;
            chatLogBox.TabIndex = 1;
            chatLogBox.CellDoubleClick += chatLogBox_CellDoubleClick;
            chatLogBox.KeyDown += chatLogBox_KeyDown;
            // 
            // messages
            // 
            messages.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            messages.HeaderText = "Messages";
            messages.MaxInputLength = 5000;
            messages.MinimumWidth = 6;
            messages.Name = "messages";
            messages.ReadOnly = true;
            messages.Resizable = DataGridViewTriState.False;
            messages.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // person
            // 
            person.HeaderText = "Sender";
            person.MinimumWidth = 6;
            person.Name = "person";
            person.ReadOnly = true;
            person.Resizable = DataGridViewTriState.False;
            person.SortMode = DataGridViewColumnSortMode.NotSortable;
            person.Width = 61;
            // 
            // time
            // 
            time.HeaderText = "Time";
            time.MinimumWidth = 6;
            time.Name = "time";
            time.ReadOnly = true;
            time.Resizable = DataGridViewTriState.False;
            time.SortMode = DataGridViewColumnSortMode.NotSortable;
            time.Width = 48;
            // 
            // msgID
            // 
            msgID.HeaderText = "Message ID";
            msgID.MinimumWidth = 6;
            msgID.Name = "msgID";
            msgID.ReadOnly = true;
            msgID.Visible = false;
            msgID.Width = 115;
            // 
            // chatLogBoxRightClickMenu
            // 
            chatLogBoxRightClickMenu.ImageScalingSize = new Size(20, 20);
            chatLogBoxRightClickMenu.Items.AddRange(new ToolStripItem[] { showFullMessageToolStripMenuItem, deleteContactsToolStripMenuItem });
            chatLogBoxRightClickMenu.Name = "chatLogBoxRightClickMenu";
            chatLogBoxRightClickMenu.RenderMode = ToolStripRenderMode.System;
            chatLogBoxRightClickMenu.Size = new Size(252, 52);
            // 
            // showFullMessageToolStripMenuItem
            // 
            showFullMessageToolStripMenuItem.Name = "showFullMessageToolStripMenuItem";
            showFullMessageToolStripMenuItem.Size = new Size(251, 24);
            showFullMessageToolStripMenuItem.Text = "Show Full Message";
            showFullMessageToolStripMenuItem.Click += showFullMessageToolStripMenuItem_Click;
            // 
            // deleteContactsToolStripMenuItem
            // 
            deleteContactsToolStripMenuItem.Name = "deleteContactsToolStripMenuItem";
            deleteContactsToolStripMenuItem.Size = new Size(251, 24);
            deleteContactsToolStripMenuItem.Text = "Delete Selected Messages";
            deleteContactsToolStripMenuItem.Click += deleteContactsToolStripMenuItem_Click;
            // 
            // splitContainer6
            // 
            splitContainer6.BackColor = Color.CadetBlue;
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.IsSplitterFixed = true;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            splitContainer6.Orientation = Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(splitContainer10);
            splitContainer6.Size = new Size(812, 123);
            splitContainer6.SplitterDistance = 57;
            splitContainer6.TabIndex = 10;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(lblAlertInfo);
            splitContainer5.Panel1.Controls.Add(lblCharCount);
            splitContainer5.Panel1.Padding = new Padding(20, 5, 5, 5);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(btnHeadsUpLeft);
            splitContainer5.Panel2.Controls.Add(btnHeadsUpRight);
            splitContainer5.Panel2.Padding = new Padding(5, 5, 20, 5);
            splitContainer5.Size = new Size(812, 57);
            splitContainer5.SplitterDistance = 671;
            splitContainer5.TabIndex = 18;
            // 
            // lblAlertInfo
            // 
            lblAlertInfo.Dock = DockStyle.Right;
            lblAlertInfo.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblAlertInfo.ForeColor = Color.AliceBlue;
            lblAlertInfo.Location = new Point(581, 5);
            lblAlertInfo.Name = "lblAlertInfo";
            lblAlertInfo.Size = new Size(85, 47);
            lblAlertInfo.TabIndex = 18;
            lblAlertInfo.Text = "Alert";
            lblAlertInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHeadsUpLeft
            // 
            btnHeadsUpLeft.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHeadsUpLeft.BackColor = Color.LightCyan;
            btnHeadsUpLeft.Cursor = Cursors.Hand;
            btnHeadsUpLeft.Dock = DockStyle.Left;
            btnHeadsUpLeft.Font = new Font("Lucida Sans Typewriter", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHeadsUpLeft.Location = new Point(5, 5);
            btnHeadsUpLeft.Name = "btnHeadsUpLeft";
            btnHeadsUpLeft.Size = new Size(50, 47);
            btnHeadsUpLeft.TabIndex = 14;
            btnHeadsUpLeft.Text = "<";
            btnHeadsUpLeft.UseVisualStyleBackColor = false;
            btnHeadsUpLeft.Click += btnHeadsUpLeft_Click;
            // 
            // btnHeadsUpRight
            // 
            btnHeadsUpRight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHeadsUpRight.BackColor = Color.LightCyan;
            btnHeadsUpRight.Cursor = Cursors.Hand;
            btnHeadsUpRight.Dock = DockStyle.Right;
            btnHeadsUpRight.Font = new Font("Lucida Sans Typewriter", 10.8F, FontStyle.Bold);
            btnHeadsUpRight.Location = new Point(67, 5);
            btnHeadsUpRight.Name = "btnHeadsUpRight";
            btnHeadsUpRight.Size = new Size(50, 47);
            btnHeadsUpRight.TabIndex = 15;
            btnHeadsUpRight.Text = ">";
            btnHeadsUpRight.UseVisualStyleBackColor = false;
            btnHeadsUpRight.Click += btnHeadsUpRight_Click;
            // 
            // splitContainer10
            // 
            splitContainer10.Dock = DockStyle.Fill;
            splitContainer10.IsSplitterFixed = true;
            splitContainer10.Location = new Point(0, 0);
            splitContainer10.Name = "splitContainer10";
            // 
            // splitContainer10.Panel1
            // 
            splitContainer10.Panel1.BackColor = Color.CadetBlue;
            splitContainer10.Panel1.Controls.Add(txtArea);
            splitContainer10.Panel1.Padding = new Padding(20, 5, 5, 5);
            // 
            // splitContainer10.Panel2
            // 
            splitContainer10.Panel2.Controls.Add(Send);
            splitContainer10.Panel2.Padding = new Padding(5, 5, 20, 5);
            splitContainer10.Size = new Size(812, 62);
            splitContainer10.SplitterDistance = 671;
            splitContainer10.TabIndex = 4;
            // 
            // txtArea
            // 
            txtArea.AcceptsTab = true;
            txtArea.BackColor = Color.Silver;
            txtArea.Dock = DockStyle.Fill;
            txtArea.Location = new Point(20, 5);
            txtArea.MaxLength = 5000;
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(646, 52);
            txtArea.TabIndex = 2;
            txtArea.Text = "";
            txtArea.TextChanged += txtArea_TextChanged;
            txtArea.KeyDown += txtArea_KeyDown;
            // 
            // tipContacts
            // 
            tipContacts.ToolTipTitle = "Full Name:";
            // 
            // Sender_MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "Sender_MainForm";
            Opacity = 0D;
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Texter App - Messages";
            FormClosing += Client_MainForm_FormClosing;
            Shown += Client_MainForm_Shown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer7.Panel1.ResumeLayout(false);
            splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
            lstRightClickMenu.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chatLogBox).EndInit();
            chatLogBoxRightClickMenu.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer10.Panel1.ResumeLayout(false);
            splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer10).EndInit();
            splitContainer10.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyTrayIcon;
        private Button Send;
        private Label lblCharCount;
        private SplitContainer splitContainer1;
        private RichTextBox txtArea;
        private ListBox lstContacts;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private DataGridView chatLogBox;
        private DataGridViewTextBoxColumn messages;
        private DataGridViewTextBoxColumn person;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn msgID;
        private Label lblIp;
        private Button btnHeadsUpLeft;
        private Button btnHeadsUpRight;
        private SplitContainer splitContainer6;
        private ToolTip tipContacts;
        private SplitContainer splitContainer7;
        private Button btnToggleServer;
        private Button btnSettings;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer10;
        private ContextMenuStrip lstRightClickMenu;
        private ToolStripMenuItem renameContactToolStripMenuItem;
        private ContextMenuStrip chatLogBoxRightClickMenu;
        private ToolStripMenuItem deleteContactsToolStripMenuItem;
        private ToolStripMenuItem showFullMessageToolStripMenuItem;
        private Label lblAlertInfo;
    }
}
