using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IBunsService
    {
        Task<IEnumerable<Bun>> GetAllAsync();
        Task<IEnumerable<Bun>> GetAvailableAsync();
        Task<Bun> GetAsync(long id);
        Task<Bun> UpdateAsync(long id, Bun bun);
        Task<Bun> AddAsync(Bun burger);
        Task<Bun> DeleteAsync(long id);
        Task<decimal> GetBunPriceAsync(long id);
    }
}
