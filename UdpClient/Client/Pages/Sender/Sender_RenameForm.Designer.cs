namespace Texter_App.Client.Pages
{
    partial class Sender_RenameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sender_RenameForm));
            lblOldName = new Label();
            newName = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblOldName
            // 
            lblOldName.BackColor = Color.Transparent;
            lblOldName.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOldName.Location = new Point(12, 9);
            lblOldName.Name = "lblOldName";
            lblOldName.Size = new Size(413, 25);
            lblOldName.TabIndex = 0;
            lblOldName.Text = "Placeholder Old Name";
            lblOldName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // newName
            // 
            newName.BackColor = Color.AliceBlue;
            newName.Location = new Point(12, 66);
            newName.Name = "newName";
            newName.Size = new Size(413, 27);
            newName.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.AliceBlue;
            btnSave.Location = new Point(12, 117);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(413, 37);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // Sender_RenameForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(437, 174);
            Controls.Add(btnSave);
            Controls.Add(newName);
            Controls.Add(lblOldName);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(455, 221);
            Name = "Sender_RenameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rename Contact";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOldName;
        private TextBox newName;
        private Button btnSave;
    }
}