using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace test.Models.Railway
{
    [DataContract]
    public class Type
    {
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        [DataMember]
        [JsonProperty("letter")]
        public string Letter { get; set; }

        [DataMember]
        [JsonProperty("places")]
        public uint Places { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Places}";
        }
    }
}