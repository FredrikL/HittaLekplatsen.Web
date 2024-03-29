﻿using MongoDB.Bson;

namespace Lekplatser.Api.Models
{
    public class PlaygroundEntity
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public LocationEntity Loc { get; set; }

        public float Rating { get; set; }

        public bool HasSwing { get; set; }
        public bool HasSlide { get; set; }
        public bool HasSandbox { get; set; }

        public bool HasBenches { get; set; }
        public bool HasPublicToilet { get; set; }
    }
}