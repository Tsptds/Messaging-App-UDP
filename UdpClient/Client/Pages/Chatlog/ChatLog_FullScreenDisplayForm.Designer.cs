namespace Texter_App.Pages
{
    partial class ChatLog_FullScreenDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatLog_FullScreenDisplayForm));
            txtArea = new RichTextBox();
            lblSender = new Label();
            lblTime = new Label();
            SuspendLayout();
            // 
            // txtArea
            // 
            txtArea.AcceptsTab = true;
            txtArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtArea.BackColor = Color.LightGray;
            txtArea.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArea.ForeColor = Color.Black;
            txtArea.Location = new Point(12, 88);
            txtArea.Name = "txtArea";
            txtArea.ReadOnly = true;
            txtArea.Size = new Size(774, 349);
            txtArea.TabIndex = 0;
            txtArea.Text = "";
            txtArea.ZoomFactor = 1.2F;
            // 
            // lblSender
            // 
            lblSender.AutoEllipsis = true;
            lblSender.BackColor = Color.Transparent;
            lblSender.Font = new Font("Palatino Linotype", 10.8F);
            lblSender.Location = new Point(12, 9);
            lblSender.Name = "lblSender";
            lblSender.Size = new Size(776, 25);
            lblSender.TabIndex = 1;
            lblSender.Text = "PlaceHolder";
            lblSender.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.AutoEllipsis = true;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Palatino Linotype", 10.8F);
            lblTime.Location = new Point(12, 54);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(776, 25);
            lblTime.TabIndex = 2;
            lblTime.Text = "PlaceHolder";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChatLog_FullScreenDisplayForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(798, 449);
            Controls.Add(lblTime);
            Controls.Add(lblSender);
            Controls.Add(txtArea);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChatLog_FullScreenDisplayForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Texter App - Full Message";
            Resize += ChatLog_FullScreenDisplayForm_Resize;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtArea;
        private Label lblSender;
        private Label lblTime;
    }
}