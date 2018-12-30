using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IDeliveryTypesService
    {
        Task<IEnumerable<DeliveryType>> GetAllAsync();
        Task<DeliveryType> GetAsync(long id);
        Task<DeliveryType> UpdateAsync(long id, DeliveryType obj);
        Task<DeliveryType> AddAsync(DeliveryType obj);
        Task<DeliveryType> DeleteAsync(long id);
        Task<decimal> GetPriceAsync(long id);
    }
}
