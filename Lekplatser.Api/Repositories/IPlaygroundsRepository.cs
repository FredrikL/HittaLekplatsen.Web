using System.Collections.Generic;
using Lekplatser.Api.Models;
using MongoDB.Bson;

namespace Lekplatser.Api.Repositories
{
    public interface IPlaygroundsRepository
    {
        IEnumerable<PlaygroundEntity> GetPlaygrounds();
        ObjectId Add(PlaygroundEntity p);
        void Update(PlaygroundEntity p);
    }
}