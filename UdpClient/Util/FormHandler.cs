using Texter_App.Runtime;

namespace Texter_App.Util
{
    public static class FormHandler
    {
        public static void InitiateFormOnStartup<T>(ref T form) where T : Form, new()
        {
            if (form == null)
            {
                form = new T();
            }
            form.Hide();
            form.Opacity = RuntimeConfigs.WindowOpacity;
        }
        public static void InitiateGeneric<T>(ref T thingymabob) where T : class, new()
        {
            if (thingymabob == null)
            {
                thingymabob = new T();
            }
        }

        public static void FormToNotification(Form _form)
        {
            _form.Hide();
        }
        public static void NotificationToForm(Form _form)
        {
            _form.Show();
            if (_form.WindowState == FormWindowState.Minimized)
            {
                _form.WindowState = FormWindowState.Normal;
            }
            // Bring the form to front and focus it
            _form.BringToFront();
            _form.Activate();
        }
    }
}