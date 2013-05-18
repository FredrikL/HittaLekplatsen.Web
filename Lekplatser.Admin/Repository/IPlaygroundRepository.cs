﻿using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Admin.Repository
{
    public interface IPlaygroundRepository
    {
        IEnumerable<Playground> GetAll();
        string Add(Playground p);
        Playground GetById(string id);
        IEnumerable<Playground> GetByLocation(float lat, float lng);
    }
}