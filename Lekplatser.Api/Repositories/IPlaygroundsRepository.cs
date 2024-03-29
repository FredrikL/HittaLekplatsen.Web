﻿using System.Collections.Generic;
using Lekplatser.Api.Models;
using MongoDB.Bson;

namespace Lekplatser.Api.Repositories
{
    public interface IPlaygroundsRepository
    {
        IEnumerable<PlaygroundEntity> GetAll();
        IEnumerable<PlaygroundEntity> GetByLocation(float lat, float lng);
        ObjectId Add(PlaygroundEntity p);
        void Update(PlaygroundEntity p);
        PlaygroundEntity GetById(string id);
        void Delete(string someId);
    }
}