using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using Lekplatser.Dto;
using ServiceStack.Text;

namespace Lekplatser.Admin.Repository
{
    public class PlaygroundRepository : IPlaygroundRepository
    {
        public IEnumerable<Playground> GetAll()
        {
            var wc = new WebClient();
            var data = wc.DownloadString(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/GetAll");
            var x = TypeSerializer.DeserializeFromString<Playground[]>(data);
            return x;
        }

        public string Add(Playground p)
        {
            var wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            var x = wc.UploadString(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/Create", "POST",
                TypeSerializer.SerializeToString(p));
        
            //var sr = new StreamReader(stream);
            //var id = sr.ReadLine();
            return "";
        } 
    }
}