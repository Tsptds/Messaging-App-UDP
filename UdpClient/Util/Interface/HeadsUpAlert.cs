using Texter_App.Pages.OnScreenAlert;

namespace Texter_App.Util.Interface
{
    public class HeadsUp
    {
        public static void Alert(bool isRight)
        {
            if (isRight)
            {
                var r = Right.Instance;
                r.Show();
                r.TriggerAlert();
            }
            else
            {
                var l = Left.Instance;
                l.Show();
                l.TriggerAlert();
            }
        }
    }
}