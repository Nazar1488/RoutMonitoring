using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace test.Models.Railway
{
    [DataContract]
    public class TrainsInfo
    {
        [DataMember]
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}