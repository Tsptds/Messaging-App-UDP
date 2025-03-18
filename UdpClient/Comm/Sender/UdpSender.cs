using System.Text;
using System.Net.Sockets;
using Receiver;
using System.Net;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Util.Interface;
using Texter_App.Runtime;
using Texter_App.Util.Encryption;
using Texter_App.Util;

namespace Texter_App.Comm.Sender
{
    internal static class UdpSender
    {
        private static string serverIp;
        private static int serverPort;
        public static void Send(string _message, IPAddress ip)
        {
            if (string.IsNullOrWhiteSpace(_message))
            {
                //Prompt.Alert(PromptStrings.Form.EmptyMessage); // No need for this tbh
                return;
            }
            // Define the server's IP address and UDP port.

            try
            {
                serverIp = ip.ToString();
                string readPort = SQLiteHelper.SettingsHelper.ReadPort();

                if (!int.TryParse(readPort, out serverPort))
                {
                    throw new Exception("Invalid Port In Database File, File Is Corrupt");
                }
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
                return;
            }

            // Create an instance of Client.
            using (UdpClient client = new UdpClient())
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(_message);
                    data = AesEncryption.Encrypt(data, Encoding.UTF8.GetBytes(RuntimeConfigs.Passkey));

                    // Send the message to the server.
                    client.SendAsync(data, data.Length, serverIp, serverPort);
                    //System.Media.SystemSounds.Exclamation.Play();

                    if(!IP.IsMyIp(ip))
                        Landing_MainForm.NotifyServerDebug("Message Sent");

                    Landing_MainForm.AppendToChatLog(_message, IP.MyIp().ToString(), serverIp);
                }
                catch (Exception ex)
                {
                    Prompt.Alert(PromptStrings.Form.SendError + ex.Message);
                }
            }
        }
        public static void HeadsUp(bool isRight, IPAddress ip, string name)
        {
            // Define the server's IP address and UDP port.

            try
            {
                serverIp = ip.ToString();
                string readPort = SQLiteHelper.SettingsHelper.ReadPort();

                if (!int.TryParse(readPort, out serverPort))
                {
                    throw new Exception("Invalid Port In Database File, File Is Corrupt");
                }
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
                return;
            }

            // Create an instance of Client.
            using (UdpClient client = new UdpClient())
            {
                try
                {
                    byte[] data =
                        Encoding.UTF8.GetBytes(isRight ? RuntimeConfigs.HeadsUpRightCode : RuntimeConfigs.HeadsUpLeftCode);

                    data = AesEncryption.Encrypt(data, Encoding.UTF8.GetBytes(RuntimeConfigs.Passkey));
                    // Send the message to the server.
                    client.SendAsync(data, data.Length, serverIp, serverPort);

                    System.Media.SystemSounds.Exclamation.Play();
                    //Prompt.Success($"{name} Alerted");
                    Landing_MainForm.AppendToChatLog($"Alerted <{name}> At: <{ip}>", IP.MyIp().ToString(), serverIp, false);
                }
                catch (Exception ex)
                {
                    Prompt.Alert(PromptStrings.Form.SendError + ex.Message);
                }
            }
        }
    }
}
