namespace Texter_App.Util.Interface
{
    internal class Prompt
    {
        public static bool YesNo(string text)
        {
            return MessageBox.Show(text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void Alert(string text)
        {
            MessageBox.Show(text, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Success(string text)
        {
            MessageBox.Show(text, "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static bool Quit()
        {
            return MessageBox.Show("Quit Texter App?", "Quit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static DialogResult PreSendPrompt()
        {
            return MessageBox.Show("Your receiver is off, responses won't reach you.\n" +
                    "Turn On Server First (Yes), Send Anyway (No) or Cancel", "RECEIVER OFF",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }
    }
    internal class PromptStrings
    {
        public struct YesNo
        {
            public const string Save = "Save?";
            public const string Export= "Export All Contacts?";
            public const string DeleteMessages = "This Will Delete All Selected Messages, Are You Sure?";
        }
        public struct Generic
        {
            public const string Done = "Done";
            public const string Saved = "Saved";
            public const string InstanceAlreadyRuns = "Another instance of the App is already running";
        }
        public struct Form
        {
            public const string EmptyMessage = "Sending Empty Messages Is Not Permitted";
            public const string SendError = "Error Sending Message: ";
            public const string ReceiveError = "Error Receiving Message: ";
        }
        public struct Contact
        {
            public const string AttemptedSelfIPChange = "This Contact Matches Your IP On The Current Network\n\nIf You Are Changing Your IP, Delete This And Create A New Contact";
            public const string IpSavedWithDifferentName = "This IP Is Already Saved With a Different Name";
            public const string NoContactSelection = "No Contact Selected";
            public const string InvalidIP = "Invalid IP";
        }
        public struct ImportExport
        {
            public const string ImportJSONEmpty = "Imported Json Has No Contact Records";
            public const string ImportsHadDupes = $"Some Contacts Had Duplicate Information and Were Not Imported";
            public const string SelfExportSkipped = "Skipped Exporting Self IP In Contacts";
        }

        public struct Database
        {
            public const string DataBaseNotFound = $"Database File Not Found\nApp Initialized For the First Launch.";
            public const string DbReadError = "Error while reading database file";

            public const string Constraint = "SQLite Constraint Exception:\n";


            public const string ContactNotFound = "No Such Saved Contact";
            public const string ContactAlreadyExists = "This Contact Already Exists.\nUpdating Its IP Will Also Migrate Messages Sent By It to the New IP.\n\nContinue?";
        }

    }
}
