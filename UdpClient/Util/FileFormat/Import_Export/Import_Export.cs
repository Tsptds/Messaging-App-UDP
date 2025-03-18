using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Texter_App.Util.FileFormat.JSON;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Util.Interface;

namespace Texter_App.Util.FileFormat.Import_Export
{
    public class Import_Export
    {
        public static void ExportContacts()
        {
            List<Contact> messages = SQLiteHelper.ContactHelper.FetchAllContacts();

            // Remove this PC's Entry
            int idx = messages.FindIndex(item => item.IP == IP.MyIp().ToString());
            if (idx != -1)
            {
                messages.RemoveAt(idx);
                Prompt.Alert(PromptStrings.ImportExport.SelfExportSkipped);
            }

            string fileName = "contacts_export.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string json = JsonSerializer.Serialize(messages, options);

            File.WriteAllText(fileName, json);
        }

        public static List<Contact> ImportContacts()
        {
            List<Contact> messages = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Select a JSON file to import messages";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string json = File.ReadAllText(filePath);

                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                    };
                    messages = JsonSerializer.Deserialize<List<Contact>>(json, options);
                }
            }

            return messages;
        }
    }
}
