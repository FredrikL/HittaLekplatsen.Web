using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Admin.Repository
{
    public interface IPlaygroundRepository
    {
        IEnumerable<Playground> GetAll();
        string Add(Playground p);
    }
}