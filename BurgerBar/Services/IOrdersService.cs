using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetAsync(long id);
        Task<Order> UpdateAsync(long id, Order obj);
        Task<Order> AddAsync(Order obj);
        Task<Order> DeleteAsync(long id);
    }
}
