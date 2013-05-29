using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Shared.Repository
{
    public interface IAdminPlayGroundRepository
    {
        IEnumerable<Playground> GetAll();
    }
}