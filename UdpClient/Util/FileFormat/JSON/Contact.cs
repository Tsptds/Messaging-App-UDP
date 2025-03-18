using System.Text.Json.Serialization;

namespace Texter_App.Util.FileFormat.JSON
{
    public class Contact
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ip")]
        public string IP { get; set; }
    }
}
