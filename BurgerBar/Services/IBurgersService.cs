using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IBurgersService
    {
        Task<IEnumerable<Burger>> GetAllAsync();
        Task<Burger> GetAsync(long id);
        Task<Burger> UpdateAsync(long id, Burger burger);
        Task<Burger> AddAsync(Burger burger);
        Task<Burger> DeleteAsync(long id);
        Task<Burger> GetByCodeAsync(string code);
        Task<IEnumerable<Burger>> GetAllInMenuAsync();
    }
}
