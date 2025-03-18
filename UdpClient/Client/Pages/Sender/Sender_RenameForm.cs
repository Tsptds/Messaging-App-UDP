using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Receiver;
using Texter_App.Pages;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Runtime;
using Texter_App.Util.Interface;

namespace Texter_App.Client.Pages
{
    public partial class Sender_RenameForm : Form
    {
        private static string oldName;
        private static int ID;
        private static string IP;
        public Sender_RenameForm(string _oldName, int _id, string _ip)
        {

            InitializeComponent();
            oldName = _oldName;
            ID = _id;
            IP = _ip;

            lblOldName.Text = newName.Text = oldName;
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newName.Text)) return;
            if (!Prompt.YesNo(PromptStrings.YesNo.Save)) return;

            SQLiteHelper.ContactHelper.UpdateContact(ID, newName.Text.Trim(), IP);

            await Settings_MainForm.LoadContacts();
            this.Dispose();
        }
    }
}
