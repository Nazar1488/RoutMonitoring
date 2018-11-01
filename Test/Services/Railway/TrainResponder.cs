using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using test.Models.Railway;

namespace Test.Services.Railway
{
    public class TrainResponder
    {
        public TrainsInfo Search(string from, string to, string date, string time)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://booking.uz.gov.ua/train_search/");
            request.Method = "POST";
            var postData = $"from={GetStationsInfo(from).First().Value}";
            postData += $"&to={GetStationsInfo(to).First().Value}";
            postData += $"&date={date}";
            postData += $"&time={time}";
            var dataArray = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataArray.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(dataArray, 0, dataArray.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var data = JsonConvert.DeserializeObject<TrainsInfo>(responseString);
            data.Data.List.RemoveAll(i => i.Types.Length == 0);
            return data;
        }

        public List<StationInfo> GetStationsInfo(string name)
        {
            var term = HttpUtility.UrlEncode(name);
            var request = (HttpWebRequest)WebRequest.Create($"https://booking.uz.gov.ua/train_search/station/?term={term}");
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<StationInfo>>(responseString);
            return data;
        }
    }
}