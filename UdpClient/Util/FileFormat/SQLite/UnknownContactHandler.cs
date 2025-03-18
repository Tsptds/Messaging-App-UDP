using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texter_App.Util.FileFormat.JSON;

namespace Texter_App.Util.FileFormat.SQLite
{
    public static class UnknownContactHandler
    {
        public static Contact CheckAndHandleIncomingContact(string IP)
        {
            try
            {
                var incomingIP = SQLiteHelper.ContactHelper.GetByIP(IP);

                if (incomingIP != null)
                {
                    return null;
                }

                string unknownName = $"{IP}-Unsaved{0}";

                for (int i = 0; i < 256; i++)
                {
                    unknownName = $"{IP}-Unsaved{i}";
                    Contact toCheck = new Contact()
                    {
                        IP = IP,
                        Name = unknownName,
                    };
                    var checkedContact = SQLiteHelper.ContactHelper.CheckForDupes(toCheck);
                    if (checkedContact == null)
                    {
                        SQLiteHelper.ContactHelper.SaveContact(unknownName, IP);
                        return SQLiteHelper.ContactHelper.GetByName(unknownName);
                    }

                }
                
                throw new Exception("Unknown Contact Was Not Saved, Too Many Unknowns With The Same IP");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
