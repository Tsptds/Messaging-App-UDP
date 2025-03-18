using Receiver;
using Sender;
using Texter_App.Comm.Receiver;

namespace Texter_App.Runtime;

public static class RuntimeConfigs
{
    public static volatile bool IsServerOn = false;

    public static double WindowOpacity = 0.95;
    public static Color Gradient1 = Color.CadetBlue;
    public static Color Gradient2 = Color.MediumSeaGreen;

    public static ushort MaxAllowedCharForPackage = 3000;

    public const int OnScreenAlertFadeStep = 8;
    public const int OnScreenAlertBlinkCount = 4;

    public const bool AlwaysOpenChatLog = false;
    public const string HeadsUpLeftCode = "./_x_Heads_Up_Left_x/.";
    public const string HeadsUpRightCode = "./_x_Heads_Up_Right_x/.";

    public const string DbFile = ".\\TexterApp.sqlite";

    public const string Passkey = "ZA KEY";
    public const string Passphrase = "ZA PHRASE";
    public const string Salt = "ZA SALT";

    public static void ToggleServer()
    {
        try
        {
            if (!IsServerOn) UdpListener.StartListening(); else UdpListener.StopListening();
        }
        catch (Exception ex)
        {
            UdpListener.StopListening();
            Landing_MainForm.NotifyServerDebug(ex.Message);
            return;
        }
        IsServerOn = !IsServerOn;
        Landing_MainForm.ChangeServerToggleButtonColor(IsServerOn);
        Sender_MainForm.ChangeServerButtonColor(IsServerOn);
    }
    public static void ToggleServer(bool enable)
    {
        try
        {
            if (enable)
            {
                IsServerOn = true;
                UdpListener.StartListening();
            }
            else
            {
                IsServerOn = false;
                UdpListener.StopListening();
            }
            Landing_MainForm.ChangeServerToggleButtonColor(IsServerOn);
            Sender_MainForm.ChangeServerButtonColor(IsServerOn);
        }
        catch (Exception ex)
        {
            UdpListener.StopListening();
            Landing_MainForm.NotifyServerDebug(ex.Message);
            return;
        }
    }
}