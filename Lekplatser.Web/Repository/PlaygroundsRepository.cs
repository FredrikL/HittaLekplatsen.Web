using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Lekplatser.Dto;
using Newtonsoft.Json;

namespace Lekplatser.Web.Repository
{
    public class PlaygroundsRepository : IPlaygroundsRepository
    {
        // TODO: merge with repo in Admin?
        // TODO: Cache all the things!
        public IEnumerable<Playground> GetByLocation(float lat, float lng)
        {
            var wc = new WebClient();
            var data = wc.DownloadString(ConfigurationManager.AppSettings["ApiUrl"] + "/Playgrounds/GetByLocation/?lat=" + lat + "&long=" + lng);
            var x = JsonConvert.DeserializeObject<Playground[]>(data);
            return x;
        }
    }
}