using Newtonsoft.Json;

namespace test.Models.Railway
{
    public class StationInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}