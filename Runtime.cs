namespace Server.Util
{
    public static class RuntimeConfigs
    {
        private static ListeningPort = false;

        public void ToggleServer ()
        {
            ListeningPort = !ListeningPort;
        }
    }
}
