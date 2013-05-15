using System.Collections.Generic;
using System.Linq;
using Lekplatser.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Lekplatser.Api.Repositories
{
    public class PlaygroundsRepository : BaseRepository, IPlaygroundsRepository
    {
        public IEnumerable<PlaygroundEntity> GetAll()
        {
            return GetCollection().FindAll();
        }

        public IEnumerable<PlaygroundEntity> GetByLocation(float lat, float lng)
        {
            var earthRadius = 6378.0; // km
            var rangeInKm = 2.0; // km

            GetCollection().EnsureIndex(IndexKeys.GeoSpatial("Loc"));

            //var near =
            //    Query.GT("ExpiresOn", now);

            var options = GeoNearOptions
                .SetMaxDistance(rangeInKm / earthRadius /* to radians */)
                .SetSpherical(true);

            GeoNearResult<PlaygroundEntity> results = GetCollection().GeoNear(
                Query.Null,
               lng, // note the order
                lat,  // [lng, lat]
                200,
                options
            );

            return results.Hits.Select(result => result.Document);
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