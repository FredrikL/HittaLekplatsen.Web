using System.Collections.Generic;
using Lekplatser.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lekplatser.Api.Repositories
{
    public class PlaygroundsRepository : BaseRepository
    {
        public IEnumerable<PlaygroundEntity> GetPlaygrounds()
        {
            return GetCollection().FindAll();
        }

        public ObjectId Add(PlaygroundEntity p)
        {
            GetCollection().Insert(p);
            return p.Id;
        }

        public void Update(PlaygroundEntity p)
        {
            GetCollection().Save(p);
        }

        private MongoCollection<PlaygroundEntity> GetCollection()
        {
            return GetDataBase().GetCollection<PlaygroundEntity>("playgrounds");
        }
    }
}