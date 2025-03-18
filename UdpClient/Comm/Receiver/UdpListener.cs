#pragma warning disable CS0168
using System.Net.Sockets;
using System.Net;
using System.Text;
using Texter_App.Util.FileFormat.SQLite;
using Texter_App.Util;
using Texter_App.Util.Interface;
using Texter_App.Runtime;
using Receiver;
using Texter_App.Util.Encryption;
using Texter_App.Pages;
using Sender;

namespace Texter_App.Comm.Receiver
{
    internal static class UdpListener
    {
        private static UdpClient? server;
        private static int ParsedPort;

        public static async void StartListening()
        {
            // Define the port to listen on.
            try
            {
                string readport = SQLiteHelper.SettingsHelper.ReadPort();

                if (!int.TryParse(readport, out ParsedPort))
                {
                    throw new Exception("Invalid Port In Database File, File Is Corrupt");
                }
            }
            catch (Exception ex)
            {
                Prompt.Error(ex);
                return;
            }


            using (server = new UdpClient(ParsedPort))
            {
                try
                {
                    Landing_MainForm.ChangeServerToggleButtonColor(true);
                    while (true)
                    {
                        // Asynchronously receive data.
                        UdpReceiveResult result = await server.ReceiveAsync();
                        IPEndPoint remoteEP = result.RemoteEndPoint;
                        byte[] data = result.Buffer;
                        data = AesEncryption.Decrypt(data, Encoding.UTF8.GetBytes(RuntimeConfigs.Passkey));
                        string message = Encoding.UTF8.GetString(data);

                        //MessageBox.Show($"{message}", $"Received from {remoteEP.Address}:{remoteEP.Port}",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
#if DEBUG
                        // Test for unknown IP detection, override all incoming IPs
                        remoteEP.Address = IPAddress.Parse("192.168.1.103");
#endif
                        var checkedContact = UnknownContactHandler.CheckAndHandleIncomingContact(remoteEP.Address.ToString().Trim());
                        if (checkedContact != null)
                        {
                            await Settings_MainForm.LoadContacts();
                        }

                        if (message.Equals(RuntimeConfigs.HeadsUpLeftCode))
                            HeadsUp.Alert(false);
                        else if (message.Equals(RuntimeConfigs.HeadsUpRightCode))
                            HeadsUp.Alert(true);
                        else
                        {
                            // Temporary (or not) solution to not show duplicate messages on chat log for using self IP
#if !DEBUG
                            if (!IP.IsMyIp(remoteEP.Address))
#endif
                            {
                                Landing_MainForm.NotifyIncomingMessage(message);
                                Landing_MainForm.AppendToChatLog(message, remoteEP.Address.ToString().Trim(), IP.MyIp().ToString());
                            }
                        }
                    }
                }
                catch (SocketException ex)
                {
                    Landing_MainForm.NotifyServerDebug("Listener Shut Down");
                }
                catch (Exception ex)
                {
                    Prompt.Alert(PromptStrings.Form.ReceiveError + ex.Message);
                }
                RuntimeConfigs.ToggleServer(false);
            }
        }
        public static void StopListening()
        {
            if (server != null) server.Close();
        }
    }
}
