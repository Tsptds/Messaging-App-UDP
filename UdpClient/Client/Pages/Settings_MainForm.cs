using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using Receiver;
using Sender;
using Texter_App.Runtime;
using Texter_App.Util;
using Texter_App.Util.FileFormat.JSON;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Util.Interface;

namespace Texter_App.Pages
{
    public partial class Settings_MainForm : Form
    {
        private static string dbFile = RuntimeConfigs.DbFile;
        private static List<Contact> _importedIPs;

        private static ComboBox _cbxNames;
        private static TextBox _txtIPs;


        public Settings_MainForm()
        {
            InitializeComponent();
            _importedIPs = Landing_MainForm._IPs;

            _cbxNames = cbxNames;
            _txtIPs = txtIPs;

            try
            {
                InitPage();
            }
            catch (Exception ex)
            {
                Prompt.Alert(PromptStrings.Database.DbReadError + ex.Message);
            }
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
        private void Settings_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            FormHandler.FormToNotification(this);
        }

        public async void InitPage()
        {
            try
            {
                if (!File.Exists(dbFile))
                {
                    SQLiteHelper.SettingsHelper.CreateDatabaseTables();
                    Prompt.Alert(PromptStrings.Database.DataBaseNotFound);
                }
                await LoadSettings();
                await LoadContacts();
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }
        public async Task LoadSettings()
        {
            try
            {
                string readPort = SQLiteHelper.SettingsHelper.ReadPort();
                if (!int.TryParse(readPort, out int portVal))
                {
                    SQLiteHelper.SettingsHelper.SavePort(11000);
                    throw new Exception("Saved Port Is Not Numeric, Defaulted to 11000");
                }
                txtPort.Text = portVal.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Settings: " + ex.Message);
            }
        }
        public static async Task LoadContacts()
        {
            try
            {
                _cbxNames.Text = string.Empty;
                _txtIPs.Text = string.Empty;

                _cbxNames.Items.Clear();
                _importedIPs.Clear();

                List<Contact> list = SQLiteHelper.ContactHelper.FetchAllContacts();
                foreach (var json in list)
                {
                    _importedIPs.Add(json);
                    _cbxNames.Items.Add(json.Name);
                }

                Sender_MainForm.UpdateContactsList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Contacts: " + ex.Message);
            }
        }

        private async void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                string name_ = cbxNames.Text.Trim();
                string ip_ = txtIPs.Text.Trim();
                IPAddress ipParsed_;

                if (string.IsNullOrWhiteSpace(name_))
                {
                    Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                    return;
                }
                if (!IPAddress.TryParse(ip_, out ipParsed_))
                {
                    Prompt.Alert(PromptStrings.Contact.InvalidIP);
                    return;
                }

                if (!Prompt.YesNo(PromptStrings.YesNo.Save)) return;

                var dupe = _importedIPs.FirstOrDefault(item => item.Name == cbxNames.Text.Trim());
                bool duplicatesExist = dupe != null;

                string finalMessage = "Contact Saved";

                if (duplicatesExist)
                {
                    if (SQLiteHelper.ContactHelper.CheckSelfIPBeforeUpdate(name_))
                    {
                        throw new Exception(PromptStrings.Contact.AttemptedSelfIPChange);
                    }

                    if (!Prompt.YesNo(PromptStrings.Database.ContactAlreadyExists)) return;

                    //_importedIPs[dupe].IP = ip_;
                    SQLiteHelper.ContactHelper.UpdateContact(dupe.ID, name_, ip_);
                    SQLiteHelper.MessageHelper.MigrateMessagesOfIP(dupe.IP, ip_);
                    finalMessage = $"Existing Contact <{dupe.Name}>'s IP Changed to <{ip_}>";
                }
                else
                {
                    //Contact contact = new Contact
                    //{
                    //    IP = ip_,
                    //    Name = name_,
                    //};
                    //_importedIPs.Add(contact);
                    SQLiteHelper.ContactHelper.SaveContact(name_, ip_);
                }


                Prompt.Success(finalMessage);

                await LoadContacts();
            }
            catch (SQLiteException ex)
            {
                Prompt.Alert(PromptStrings.Contact.IpSavedWithDifferentName);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private async void btnDeleteContact_Click(object sender, EventArgs e)
        {
            try
            {
                var contact = _importedIPs.FirstOrDefault(item => item.Name == cbxNames.Text.Trim());

                if (contact == null)
                {
                    Prompt.Alert(PromptStrings.Contact.NoContactSelection);
                    return;
                }

                SQLiteHelper.ContactHelper.DeleteContact(contact.ID);

                Prompt.Success($"Deleted Contact <{contact.Name}>");

                await LoadContacts();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Prompt.Alert(PromptStrings.Database.ContactNotFound);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private void btnSavePort_Click(object sender, EventArgs e)
        {
            try
            {
                int ParsedPort;
                if (!int.TryParse(txtPort.Text.Trim(), out ParsedPort))
                {
                    throw new Exception("Port Is Not Numeric");
                }
                SQLiteHelper.SettingsHelper.SavePort(ParsedPort);

                RuntimeConfigs.ToggleServer(false);
                Prompt.Success(PromptStrings.Generic.Saved);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }

        private void cbxNames_TextChanged(object sender, EventArgs e)
        {
            var currentItem = _importedIPs.FirstOrDefault(item => item.Name == cbxNames.Text.Trim());

            //txtIPs.Text = currentItem != null ? currentItem.IP.ToString() : string.Empty;
            if (currentItem != null)
            {
                txtIPs.Text = currentItem.IP.ToString();
            }
        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            if (!Prompt.YesNo(PromptStrings.YesNo.Export)) return;

            Util.FileFormat.Import_Export.Import_Export.ExportContacts();

            Prompt.Success(PromptStrings.Generic.Done);
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            bool encounteredDupes = false;
            try
            {
                List<Contact> contacts = Util.FileFormat.Import_Export.Import_Export.ImportContacts();

                if (contacts == null) return;

                if (contacts.Capacity < 1)
                {
                    Prompt.Alert(PromptStrings.ImportExport.ImportJSONEmpty);
                    return;
                }

                foreach (Contact contact in contacts)
                {
                    if (SQLiteHelper.ContactHelper.CheckForDupes(contact) != null)
                    {
                        encounteredDupes = true;
                        continue;
                    }

                    SQLiteHelper.ContactHelper.SaveContact(contact.Name, contact.IP);
                }
                await LoadContacts();

                if (encounteredDupes)
                    Prompt.Alert(PromptStrings.ImportExport.ImportsHadDupes);
                else
                    Prompt.Success(PromptStrings.Generic.Done);
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
            }
        }
    }
}