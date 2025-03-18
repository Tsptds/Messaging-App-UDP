using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace Texter_App.Util
{
    public static class IP
    {
        public static bool IsMyIp(IPAddress incomingIP)
        {
            // If the incoming IP is a loopback address, it’s local.
            if (IPAddress.IsLoopback(incomingIP))
                return true;

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Optionally filter for active interfaces
                if (netInterface.OperationalStatus != OperationalStatus.Up)
                    continue;

                foreach (UnicastIPAddressInformation addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                {
                    if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (addrInfo.Address.Equals(incomingIP))
                            return true;
                    }
                }
            }
            return false;
        }
        public static IPAddress MyIp()
        {
            // If the incoming IP is a loopback address, it’s local.

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Optionally filter for active interfaces
                if (netInterface.OperationalStatus != OperationalStatus.Up)
                    continue;

                foreach (UnicastIPAddressInformation addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                {
                    if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return addrInfo.Address;
                    }
                }
            }
            return null;
        }
    }
}
