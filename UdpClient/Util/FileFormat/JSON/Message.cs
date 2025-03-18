using System.Text.Json.Serialization;

namespace Texter_App.Util.FileFormat.JSON
{
    public class Message
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("message")]
        public string MessageString { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        [JsonPropertyName("read_status")]
        public bool IsRead { get; set; }
    }
}
