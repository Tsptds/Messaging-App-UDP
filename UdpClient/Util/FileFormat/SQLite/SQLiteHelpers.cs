using System.Data.SQLite;
using Texter_App.Runtime;
using Texter_App.Util.Interface;
using Texter_App.Util.FileFormat.JSON;
using Message = Texter_App.Util.FileFormat.JSON.Message;
using System.Data.SqlClient;
using System.Net;

namespace Texter_App.Util.FileFormat.SQLite
{
    public static class SQLiteHelper
    {
        // Hardcoding the filename, will create new DB file if it is missing.
        private static string _dbFilePath = RuntimeConfigs.DbFile;

        /// <summary>
        /// CONTACT METHODS
        /// </summary>
        public struct ContactHelper
        {
            /// <summary>
            /// Save a contact
            /// </summary>
            public static void SaveContact(string name, string ip)
            {
                try
                {
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Contacts (name, ip) VALUES (@name, @ip)";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@ip", ip);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode != SQLiteErrorCode.Constraint)
                        throw new Exception(ex.Message);

                    throw new SQLiteException(SQLiteErrorCode.Constraint, "SQLite Constraint Exception:\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    Prompt.Error(ex);
                }
            }

            /// <summary>
            /// Delete a contact.
            /// </summary>
            public static void DeleteContact(int id)
            {
                try
                {
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT ip FROM Contacts WHERE id = @id";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string contactIP = reader["ip"].ToString();

                                    sql = "DELETE FROM Messages WHERE sender = @sender AND receiver = @receiver OR sender = @receiver AND receiver = @sender";

                                    using (SQLiteCommand command2 = new SQLiteCommand(sql, connection))
                                    {
                                        command2.Parameters.AddWithValue("@sender", contactIP);
                                        command2.Parameters.AddWithValue("@receiver", IP.MyIp());
                                        command2.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        sql = "DELETE FROM Contacts WHERE id = @id;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Prompt.Error(ex);
                }
            }

            /// <summary>
            /// Update a contact's IP from its name.
            /// </summary>
            
            public static bool CheckSelfIPBeforeUpdate(string name)
            {
                if (IP.IsMyIp(IPAddress.Parse(GetByName(name).IP)))
                {
                    return true;
                }
                return false;
            }
            public static void UpdateContact(int id, string name, string IP)
            {
                    try
                    {
                        string connectionString = $"Data Source={_dbFilePath};Version=3;";
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "UPDATE Contacts SET ip = @ip, name = @name WHERE id = @id;";
                            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@ip", IP);
                                command.Parameters.AddWithValue("@name", name);
                                command.Parameters.AddWithValue("@id", id);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Prompt.Error(ex);
                    }
            }

            /// <summary>
            /// Fetch all contacts from DB into a list of Contact objects.
            /// </summary>
            public static List<Contact> FetchAllContacts()
            {
                List<Contact> list = new();
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Contacts";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Safely read the "IP" column from each row
                                int id = int.Parse(reader["id"].ToString());
                                string name = reader["name"].ToString();
                                string ip = reader["ip"].ToString();

                                Contact json = new Contact()
                                {
                                    ID = id,
                                    Name = name,
                                    IP = ip
                                };
                                list.Add(json);
                            }
                        }
                        return list;
                    }
                }
            }

            /// <summary>
            /// Don't use, for debugging
            /// </summary>
            /// <returns>Prints All contacts to MBox 1 by 1</returns>
            public static void DebugReadAll()
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Contacts";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Safely read the "IP" column from each row
                                string id = reader["id"].ToString();
                                string name = reader["name"].ToString();
                                string ip = reader["ip"].ToString();
                                MessageBox.Show(id + " : " + name + " : " + ip);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Search by Name, Return its IP.
            /// </summary>
            //public static string SearchForNameAndReturnIP(string value)
            //{
            //    string sql = "SELECT * FROM Contacts WHERE name = @value";
            //    return Search(sql, value, "ip");
            //}

            ///// <summary>
            ///// Search by IP, Return its Name.
            ///// </summary>
            //public static string SearchForIPAndReturnName(string value)
            //{
            //    string sql = "SELECT * FROM Contacts WHERE ip = @value";

            //    return Search(sql, value, "name");
            //}

            /// <summary>
            /// Return contact if it has matching info, otherwise return null
            /// </summary>
            public static Contact CheckForDupes(Contact toCheck)
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Contacts WHERE name = @name OR ip = @ip";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", toCheck.Name);
                        command.Parameters.AddWithValue("@ip", toCheck.IP);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Contact contact = new Contact()
                                {
                                    ID = int.Parse(reader["id"].ToString()),
                                    Name = reader["name"].ToString(),
                                    IP = reader["ip"].ToString()

                                };
                                return contact;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Return contact from name
            /// </summary>
            public static Contact GetByName(string name)
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Contacts WHERE name = @name";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Contact contact = new Contact()
                                {
                                    ID = int.Parse(reader["id"].ToString()),
                                    Name = reader["name"].ToString(),
                                    IP = reader["ip"].ToString()

                                };
                                return contact;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Return contact from IP
            /// </summary>
            public static Contact GetByIP(string IP)
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Contacts WHERE ip = @ip";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ip", IP);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Contact contact = new Contact()
                                {
                                    ID = int.Parse(reader["id"].ToString()),
                                    Name = reader["name"].ToString(),
                                    IP = reader["ip"].ToString()

                                };
                                return contact;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// SETTINGS METHODS
        /// </summary>
        public struct SettingsHelper
        {
            /// <summary>
            /// Create blank DB file with preset configs.
            /// </summary>
            public static void CreateDatabaseTables()
            {
                if (!File.Exists(_dbFilePath))
                {
                    SQLiteConnection.CreateFile(_dbFilePath);
                }

                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                            CREATE TABLE IF NOT EXISTS Contacts (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                name TEXT NOT NULL UNIQUE,
                                ip TEXT NOT NULL UNIQUE
                            );
                            CREATE TABLE IF NOT EXISTS Settings (
                                port INTEGER NOT NULL UNIQUE
                            );
                            CREATE TABLE Messages (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                message TEXT NOT NULL,
                                date TEXT NOT NULL,
                                sender TEXT NOT NULL,
                                receiver TEXT NOT NULL,
                                read_status INTEGER NOT NULL DEFAULT 0
                            );

                        ";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Local IP as a demo contact.
                Contact blankFile = new Contact()
                {
                    Name = "My IP On Network",
                    //IP = "127.0.0.1"
                    IP = IP.MyIp().ToString()
                };

                ContactHelper.SaveContact(blankFile.Name, blankFile.IP);
                SavePort(11000);
            }

            /// <summary> 
            /// Save the _port setting
            /// </summary>
            public static void SavePort(int port)
            {
                try
                {
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        // Check if a row already exists in the Settings table.
                        string checkSql = "SELECT COUNT(*) FROM Settings;";
                        using (SQLiteCommand checkCommand = new SQLiteCommand(checkSql, connection))
                        {
                            long count = (long)checkCommand.ExecuteScalar();
                            string sql = count == 0
                                ? "INSERT INTO Settings (port) VALUES (@port);"
                                : "UPDATE Settings SET port = @port;";

                            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@port", port);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode != SQLiteErrorCode.Constraint)
                        throw new Exception(ex.Message);

                    throw new Exception("SQLite Constraint Exception:\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    Prompt.Error(ex);
                }
            }

            /// <summary> 
            /// Read the _port setting
            /// </summary>
            public static string ReadPort()
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT port FROM SETTINGS;";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader["port"].ToString();
                            }
                            else
                            {
                                throw new Exception("Port setting not found.");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// MESSAGE METHODS
        /// </summary>
        public struct MessageHelper
        {
            /// <summary>
            /// Save a Message
            /// </summary>
            public static void SaveMessage(string message, DateTime date, string sender, string receiver, bool readStatus)
            {
                try
                {
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Messages (message, date, sender, receiver, read_status) VALUES (@m, @d, @s, @r, @rs)";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@m", message);
                            command.Parameters.AddWithValue("@d", date);
                            command.Parameters.AddWithValue("@s", sender);
                            command.Parameters.AddWithValue("@r", receiver);
                            command.Parameters.AddWithValue("@rs", readStatus);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode != SQLiteErrorCode.Constraint)
                        throw new Exception(ex.Message);

                    Prompt.Alert(PromptStrings.Database.Constraint + ex.Message);
                }
                catch (Exception ex)
                {
                    Prompt.Error(ex);
                }
            }

            /// <summary>
            /// Delete a Message.
            /// </summary>
            public static void DeleteMessage(int id)
            {
                try
                {
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "DELETE FROM Messages WHERE id = @id;";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Prompt.Error(ex);
                }
            }

            /// <summary>
            /// Fetch all Messages from DB into a list of Contact objects.
            /// </summary>
            public static List<Message> FetchAllMessagesForContact(string contact, string me)
            {
                List<Message> list = new();
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Messages WHERE sender = @sender AND receiver = @receiver OR sender = @receiver AND receiver = @sender";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        // Return messages where contact is sender and I'm receiver, or vice versa
                        command.Parameters.AddWithValue("@sender", contact);
                        command.Parameters.AddWithValue("@receiver", me);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = int.Parse(reader["id"].ToString());

                                string message = reader["message"].ToString();

                                DateTime date = DateTime.Parse(reader["date"].ToString());

                                string sender = reader["sender"].ToString();

                                bool readStatus = reader["read_status"].ToString() == "0" ? false : true;

                                Message json = new Message()
                                {
                                    ID = id,
                                    MessageString = message,
                                    Date = date,
                                    Sender = sender,
                                    IsRead = readStatus
                                };
                                list.Add(json);
                            }
                        }
                        return list;
                    }
                }
            }

            /// <summary>
            /// Search by a column, return another column value with the given query.
            /// </summary>
            public static Message GetByID(int id)
            {
                string connectionString = $"Data Source={_dbFilePath};Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Messages WHERE id = @id";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //int id = int.Parse(reader["id"].ToString());

                                string message = reader["message"].ToString();

                                DateTime date = DateTime.Parse(reader["date"].ToString());

                                string sender = reader["sender"].ToString();

                                bool readStatus = reader["read_status"].ToString() == "0" ? false : true;

                                Message json = new Message()
                                {
                                    ID = id,
                                    MessageString = message,
                                    Date = date,
                                    Sender = sender,
                                    IsRead = readStatus
                                };
                                return json;
                            }
                            else
                            {
                                throw new Exception("Message With the Given ID Is Not Available");
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Migrate all chats of previous IP to new IP.
            /// </summary>
            public static void MigrateMessagesOfIP(string oldIP, string newIP)
            {
                try
                {
                    List<Contact> list = new();
                    string connectionString = $"Data Source={_dbFilePath};Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string sql = @"UPDATE Messages
                                        SET 
                                            sender = CASE WHEN sender = @oldIP THEN @newIP ELSE sender END,
                                            receiver = CASE WHEN receiver = @oldIP THEN @newIP ELSE receiver END
                                        WHERE sender = @oldIP OR receiver = @oldIP;
";
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@newIP", newIP);
                            command.Parameters.AddWithValue("@oldIP", oldIP);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Message Migration Failed: " + ex.Message);
                }
            }
        }
    }
}