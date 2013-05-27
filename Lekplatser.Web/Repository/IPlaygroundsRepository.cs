using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Web.Repository
{
    public interface IPlaygroundsRepository
    {
        IEnumerable<Playground> GetByLocation(float lat, float lng);
    }
}