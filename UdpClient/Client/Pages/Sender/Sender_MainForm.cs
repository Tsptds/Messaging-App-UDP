using System;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using Receiver;
using Texter_App.Client.Pages;
using Texter_App.Comm.Sender;
using Texter_App.Pages;
using Texter_App.Runtime;
using Texter_App.Util;
using Texter_App.Util.FileFormat.JSON;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Util.Interface;

namespace Sender
{
    public partial class Sender_MainForm : Form
    {
        private static List<Contact> _importedIPs;
        private static Label _lblIpDisplay;
        private static ListBox _lstReference;
        private static DataGridView _chatLog;

        private static Button _toggleServerButtonSenderPage;
        public Sender_MainForm()
        {
            InitializeComponent();

            // Static stuff to be used in static methods, just refs to the page's private objects
            _importedIPs = Landing_MainForm._IPs;
            _lstReference = lstContacts;
            _lblIpDisplay = lblIp;
            _chatLog = chatLogBox;
            _toggleServerButtonSenderPage = btnToggleServer;

            txtArea.MaxLength = RuntimeConfigs.MaxAllowedCharForPackage;
            UpdateCharCount();
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
                LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        public static void UpdateContactsList()
        {
            _chatLog.Rows.Clear();
            _lstReference.Items.Clear();
            _lblIpDisplay.Text = string.Empty;
            foreach (var item in _importedIPs)
            {
                _lstReference.Items.Add(item.Name);
            }

        }
        private void UpdateCharCount()
        {
            lblCharCount.Text = txtArea.Text.Length.ToString() + " / " + RuntimeConfigs.MaxAllowedCharForPackage.ToString();
        }

        private void Client_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            FormHandler.FormToNotification(this);
        }

        private void Client_MainForm_Shown(object sender, EventArgs e)
        {
            notifyTrayIcon.ShowBalloonTip(3);
        }
        private void Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lstReference.Text))
            {
                Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                return;
            }

            try
            {
                string package = txtArea.Text.ToString().Trim();
                CheckAndPromptForSend(package, false, false);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }


        private void CheckAndPromptForSend(string package, bool isHeadsUp, bool isHeadsUpRight)
        {
            if (RuntimeConfigs.IsServerOn)
            {
                UdpSendWithServerToggle(package, false, isHeadsUp, isHeadsUpRight);
            }
            else
            {
                DialogResult res = Prompt.PreSendPrompt();
                if (res == DialogResult.No)
                {
                    UdpSendWithServerToggle(package, false, isHeadsUp, isHeadsUpRight);
                }
                else if (res == DialogResult.Yes)
                {
                    UdpSendWithServerToggle(package, true, isHeadsUp, isHeadsUpRight);
                }
                //else if (res == DialogueResult.Cancel)
                //{
                //    Exit without doing anything
                //}
            }
        }
        private void UdpSendWithServerToggle(string package, bool toggleServer, bool isHeadsUp, bool isHeadsUpRight)
        {
            var currentItem = _importedIPs.FirstOrDefault(item => item.Name == _lstReference.Text);
            IPAddress ip = IPAddress.Parse(currentItem.IP);

            if (toggleServer == true)
            {
                RuntimeConfigs.ToggleServer(true);
            }

            if (isHeadsUp == true)
            {
                UdpSender.HeadsUp(isHeadsUpRight, ip, currentItem.Name);
            }
            else
            {
                UdpSender.Send(package, ip);
                txtArea.Text = string.Empty;
            }
        }
        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            UpdateCharCount();
        }

        private void btnHeadsUpRight_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lstReference.Text))
            {
                Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                return;
            }
            try
            {
                CheckAndPromptForSend(RuntimeConfigs.HeadsUpRightCode, true, true);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private void btnHeadsUpLeft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lstReference.Text))
            {
                Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                return;
            }
            try
            {
                CheckAndPromptForSend(RuntimeConfigs.HeadsUpRightCode, true, false);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private void RetrieveChatHistrory()
        {
            try
            {
                // Prevent crash in case index updates fail and called on deleted items
                if (_lstReference.SelectedIndex < 0) return;

                string userIP = _importedIPs.FirstOrDefault(item => item.Name == _lstReference.Text).IP;
                string myIP = IP.MyIp().ToString();
                lblIp.Text = _lstReference.Text;

                List<Texter_App.Util.FileFormat.JSON.Message> lst = SQLiteHelper.MessageHelper.FetchAllMessagesForContact(userIP, myIP);

                foreach (var msg in lst)
                {
                    var user = _importedIPs.FirstOrDefault(item => item.IP == msg.Sender);

                    String userName = user == null ? msg.Sender : user.Name;
                    DisplayChat(msg.MessageString, userName ?? msg.Sender, msg.Date, msg.ID);
                }
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }
        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chatLog.Rows.Clear();
            if (!string.IsNullOrWhiteSpace(_lstReference.Text))
            {
                RetrieveChatHistrory();
            }
        }

        public void AppendChat(string _Message, string _sender, string _receiver)
        {
            SQLiteHelper.MessageHelper.SaveMessage(_Message, DateTime.Now, _sender, _receiver, true);
            _chatLog.Rows.Clear();
            RetrieveChatHistrory();
        }
        public void DisplayChat(string _Message, string _person, DateTime _date, int _id)
        {
            _chatLog.Rows.Insert(0, _Message, _person, DateTime.Now.ToShortTimeString(), _id);
            _chatLog.CurrentCell = _chatLog.Rows[0].Cells[0];
        }

        private void chatLogBox_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetMessageAndShow(e.RowIndex, e.ColumnIndex);
        }
        private void GetMessageAndShow(int row, int col)
        {
            // If selected a non-header cell, display the entire row attributes in a new form
            if (row >= 0 && col >= 0)
            {
                DataGridViewRow selectedRow = _chatLog.Rows[row];
                //MessageBox.Show("ID:" + selectedRow.Cells[3].Value.ToString());

                ChatLog_FullScreenDisplayForm _fullscreenChat = new();

                _fullscreenChat.DisplayFullScreenMessage(selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString());
            }
        }

        private void DeleteSelectedMessages()
        {
            try
            {
                if (_chatLog.SelectedRows.Count < 1) return;

                if (!Prompt.YesNo(PromptStrings.YesNo.DeleteMessages)) return;

                foreach (DataGridViewRow row in _chatLog.SelectedRows)
                {
                    // Cell 3 is invisible, has message global ID on db
                    int idValue = int.Parse(row.Cells[3].Value.ToString());
                    SQLiteHelper.MessageHelper.DeleteMessage(idValue);
                }
                _chatLog.Rows.Clear();
                RetrieveChatHistrory();
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private void lblIp_MouseHover(object sender, EventArgs e)
        {
            tipContacts.SetToolTip(lblIp, lblIp.Text);
        }

        private void btnToggleServer_Click(object sender, EventArgs e)
        {
            RuntimeConfigs.ToggleServer();


        }
        public static void ChangeServerButtonColor(bool enable)
        {
            if (enable)
            {
                _toggleServerButtonSenderPage.Text = "On";
                _toggleServerButtonSenderPage.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                _toggleServerButtonSenderPage.Text = "Off";
                _toggleServerButtonSenderPage.BackColor = Color.Crimson;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormHandler.NotificationToForm(Landing_MainForm._settingsForm);
        }

        private void renameContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = _lstReference.SelectedIndex;


            if (index != ListBox.NoMatches)
            {
                var item = _lstReference.Items[index];
                string name = _lstReference.GetItemText(item);

                if (!Prompt.YesNo($"Rename {name}?")) return;

                Contact cont = SQLiteHelper.ContactHelper.GetByName(name);
                if (cont != null)
                {
                    Sender_RenameForm instance = new Sender_RenameForm(cont.Name, cont.ID, cont.IP);
                    instance.Show();
                }
                else
                {
                    Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                }
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!e.Shift)
                {
                    e.SuppressKeyPress = true;
                    Send.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (!e.Shift)
                    e.SuppressKeyPress = true;
            }
        }

        private void deleteContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedMessages();
        }

        private void showFullMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_chatLog.CurrentCell == null) return;
            GetMessageAndShow(_chatLog.CurrentCell.RowIndex, _chatLog.CurrentCell.ColumnIndex);
        }

        private void chatLogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_chatLog.CurrentCell == null) return;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                GetMessageAndShow(_chatLog.CurrentCell.RowIndex, _chatLog.CurrentCell.ColumnIndex);
            }
        }
    }
}