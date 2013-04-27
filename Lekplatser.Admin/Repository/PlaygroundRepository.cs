using System.Collections.Generic;
using System.Configuration;
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
    }
}