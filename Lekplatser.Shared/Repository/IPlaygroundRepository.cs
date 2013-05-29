using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Shared.Repository
{
    public interface IPlaygroundRepository
    {
        string Add(Playground p);
        Playground GetById(string id);
        IEnumerable<Playground> GetByLocation(float lat, float lng);
    }

    public interface IAdminPlayGroundRepository : IPlaygroundRepository
    {
        IEnumerable<Playground> GetAll();
    }
}