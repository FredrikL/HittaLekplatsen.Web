using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using Lekplatser.Dto;
using Newtonsoft.Json;

namespace Lekplatser.Admin.Repository
{
    public class PlaygroundRepository : IPlaygroundRepository
    {
        public IEnumerable<Playground> GetAll()
        {
            var wc = new WebClient();
            var data = wc.DownloadString(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/GetAll");
            var x = JsonConvert.DeserializeObject<Playground[]>(data);
            return x;
        }

        public string Add(Playground p)
        {
        
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/Create");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(p);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            return "";
        }

        public Playground GetById(string id)
        {
            var wc = new WebClient();
            var data = wc.DownloadString(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/ById/" + id);
            var x = JsonConvert.DeserializeObject<Playground>(data);
            return x;
        }
    }
}