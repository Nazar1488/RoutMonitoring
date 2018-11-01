using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace test.Models.Railway
{
    [DataContract]
    public class Train
    {
        [DataMember]
        [JsonProperty("num")]
        public string Num { get; set; }

        [DataMember]
        [JsonProperty("category")]
        public int Category { get; set; }

        [DataMember]
        [JsonProperty("isTransformer")]
        public int IsTransformer { get; set; }

        [DataMember]
        [JsonProperty("travelTime")]
        public string TravelTime { get; set; }

        [DataMember]
        [JsonProperty("from")]
        public Station From { get; set; }

        [DataMember]
        [JsonProperty("to")]
        public Station To { get; set; }

        [DataMember]
        [JsonProperty("types")]
        public Type[] Types { get; set; }

        [DataMember]
        [JsonProperty("child")]
        public Child Child { get; set; }

        [DataMember]
        [JsonProperty("allowStudent")]
        public int AllowStudent { get; set; }

        [DataMember]
        [JsonProperty("allowBooking")]
        public int AllowBooking { get; set; }

        [DataMember]
        [JsonProperty("isCis")]
        public int IsCis { get; set; }

        [DataMember]
        [JsonProperty("isEurope")]
        public int IsEurope { get; set; }

        [DataMember]
        [JsonProperty("allowPrivilege")]
        public int AllowPrivilege { get; set; }

        [DataMember]
        [JsonProperty("noReserve")]
        public int NoReserve { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Потяг {Num} {From.StationTrain} - {To.StationTrain}\n");
            stringBuilder.Append($"Відправляється з {From.StationName} о {From.Time}\n");
            stringBuilder.Append($"Прибуває до {To.StationName} о {To.Time}\n");
            stringBuilder.Append($"Час у дорозі {TravelTime}\n");
            stringBuilder.Append("<----==== Вільні місця ====---->\n");
            foreach (var type in Types)
            {
                stringBuilder.AppendLine(type.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}