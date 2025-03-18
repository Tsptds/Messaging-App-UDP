namespace Texter_App.Pages
{
    partial class Settings_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_MainForm));
            txtPort = new TextBox();
            lblPort = new Label();
            btnSaveContact = new Button();
            cbxNames = new ComboBox();
            lblIP = new Label();
            txtIPs = new TextBox();
            lblNickname = new Label();
            lblIPInfo = new Label();
            lblPortInfo = new Label();
            btnSavePort = new Button();
            btnDeleteContact = new Button();
            btnExports = new Button();
            lblExport = new Label();
            btnImport = new Button();
            lblSeparator = new Label();
            lblSeparatorVert = new Label();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.BackColor = Color.AliceBlue;
            txtPort.Location = new Point(61, 40);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 0;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.Transparent;
            lblPort.Location = new Point(17, 43);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(38, 20);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port:";
            // 
            // btnSaveContact
            // 
            btnSaveContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveContact.BackColor = Color.AliceBlue;
            btnSaveContact.Location = new Point(845, 141);
            btnSaveContact.Name = "btnSaveContact";
            btnSaveContact.Size = new Size(118, 46);
            btnSaveContact.TabIndex = 4;
            btnSaveContact.Text = "Save Contact";
            btnSaveContact.UseVisualStyleBackColor = false;
            btnSaveContact.Click += btnSaveContact_Click;
            // 
            // cbxNames
            // 
            cbxNames.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbxNames.BackColor = Color.AliceBlue;
            cbxNames.FormattingEnabled = true;
            cbxNames.Location = new Point(517, 60);
            cbxNames.Name = "cbxNames";
            cbxNames.Size = new Size(144, 28);
            cbxNames.TabIndex = 2;
            cbxNames.TextChanged += cbxNames_TextChanged;
            // 
            // lblIP
            // 
            lblIP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblIP.AutoSize = true;
            lblIP.BackColor = Color.Transparent;
            lblIP.Location = new Point(939, 36);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(24, 20);
            lblIP.TabIndex = 4;
            lblIP.Text = "IP:";
            lblIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtIPs
            // 
            txtIPs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtIPs.BackColor = Color.AliceBlue;
            txtIPs.Location = new Point(819, 60);
            txtIPs.Name = "txtIPs";
            txtIPs.Size = new Size(144, 27);
            txtIPs.TabIndex = 3;
            // 
            // lblNickname
            // 
            lblNickname.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblNickname.AutoSize = true;
            lblNickname.BackColor = Color.Transparent;
            lblNickname.Location = new Point(517, 36);
            lblNickname.Name = "lblNickname";
            lblNickname.Size = new Size(78, 20);
            lblNickname.TabIndex = 6;
            lblNickname.Text = "Nickname:";
            lblNickname.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPInfo
            // 
            lblIPInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIPInfo.AutoSize = true;
            lblIPInfo.BackColor = Color.Transparent;
            lblIPInfo.Location = new Point(517, 9);
            lblIPInfo.Name = "lblIPInfo";
            lblIPInfo.Size = new Size(446, 20);
            lblIPInfo.TabIndex = 7;
            lblIPInfo.Text = "Select a Name From the List to Update its IP or Type In a New One";
            lblIPInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPortInfo
            // 
            lblPortInfo.BackColor = Color.Transparent;
            lblPortInfo.Location = new Point(12, 9);
            lblPortInfo.Name = "lblPortInfo";
            lblPortInfo.Size = new Size(305, 20);
            lblPortInfo.TabIndex = 8;
            lblPortInfo.Text = "Communication Port (Default 11000)";
            lblPortInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSavePort
            // 
            btnSavePort.BackColor = Color.AliceBlue;
            btnSavePort.Location = new Point(192, 33);
            btnSavePort.Name = "btnSavePort";
            btnSavePort.Size = new Size(125, 40);
            btnSavePort.TabIndex = 1;
            btnSavePort.Text = "Save Port";
            btnSavePort.UseVisualStyleBackColor = false;
            btnSavePort.Click += btnSavePort_Click;
            // 
            // btnDeleteContact
            // 
            btnDeleteContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteContact.BackColor = Color.AliceBlue;
            btnDeleteContact.Location = new Point(517, 141);
            btnDeleteContact.Name = "btnDeleteContact";
            btnDeleteContact.Size = new Size(118, 46);
            btnDeleteContact.TabIndex = 5;
            btnDeleteContact.Text = "Delete Contact";
            btnDeleteContact.UseVisualStyleBackColor = false;
            btnDeleteContact.Click += btnDeleteContact_Click;
            // 
            // btnExports
            // 
            btnExports.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExports.BackColor = Color.AliceBlue;
            btnExports.Location = new Point(208, 132);
            btnExports.Name = "btnExports";
            btnExports.Size = new Size(109, 55);
            btnExports.TabIndex = 10;
            btnExports.Text = "Export All Contacts";
            btnExports.UseVisualStyleBackColor = false;
            btnExports.Click += btnExports_Click;
            // 
            // lblExport
            // 
            lblExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblExport.BackColor = Color.Transparent;
            lblExport.Location = new Point(17, 97);
            lblExport.Name = "lblExport";
            lblExport.Size = new Size(300, 20);
            lblExport.TabIndex = 11;
            lblExport.Text = "Import / Export Contacts JSON";
            lblExport.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImport.BackColor = Color.AliceBlue;
            btnImport.Location = new Point(17, 132);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(109, 55);
            btnImport.TabIndex = 12;
            btnImport.Text = "Import All Contacts";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // lblSeparator
            // 
            lblSeparator.BackColor = Color.Azure;
            lblSeparator.Location = new Point(12, 81);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(305, 10);
            lblSeparator.TabIndex = 13;
            // 
            // lblSeparatorVert
            // 
            lblSeparatorVert.BackColor = Color.Azure;
            lblSeparatorVert.Location = new Point(486, 9);
            lblSeparatorVert.Name = "lblSeparatorVert";
            lblSeparatorVert.Size = new Size(10, 182);
            lblSeparatorVert.TabIndex = 14;
            // 
            // Settings_MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(978, 199);
            Controls.Add(lblSeparatorVert);
            Controls.Add(lblSeparator);
            Controls.Add(btnImport);
            Controls.Add(lblExport);
            Controls.Add(btnExports);
            Controls.Add(btnDeleteContact);
            Controls.Add(btnSavePort);
            Controls.Add(lblPortInfo);
            Controls.Add(lblIPInfo);
            Controls.Add(lblNickname);
            Controls.Add(txtIPs);
            Controls.Add(lblIP);
            Controls.Add(cbxNames);
            Controls.Add(btnSaveContact);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1000, 250);
            MinimumSize = new Size(1000, 250);
            Name = "Settings_MainForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Texter App - Settings";
            FormClosing += Settings_MainForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private Label lblPort;
        private Button btnSaveContact;
        private ComboBox cbxNames;
        private Label lblIP;
        private TextBox txtIPs;
        private Label lblNickname;
        private Label lblIPInfo;
        private Label lblPortInfo;
        private Button btnSavePort;
        private Button btnDeleteContact;
        private Button btnExports;
        private Label lblExport;
        private Button btnImport;
        private Label lblSeparator;
        private Label lblSeparatorVert;
    }
}