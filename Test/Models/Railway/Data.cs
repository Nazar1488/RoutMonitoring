using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace test.Models.Railway
{
    [DataContract]
    public class Data
    {
        [DataMember]
        [JsonProperty("list")]
        public List<Train> List { get; set; }
    }
}