using MongoDB.Driver;

namespace Lekplatser.Api.Repositories
{
    public class BaseRepository
    {
        protected MongoDatabase GetDataBase()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            return server.GetDatabase("playgrounds");
        }
    }
}