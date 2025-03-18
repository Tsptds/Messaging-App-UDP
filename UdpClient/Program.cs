using Receiver;
using Texter_App.Util.Interface;

namespace Texter_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            using (Mutex mutex = new Mutex(true, "TexterApp", out isNewInstance))
            {
                if (isNewInstance)
                {
                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(true);
                    ApplicationConfiguration.Initialize();
                    Application.Run(new Landing_MainForm());
                }
                else
                {
                    Prompt.Alert(PromptStrings.Generic.InstanceAlreadyRuns);
                }
            }
        }
    }
}