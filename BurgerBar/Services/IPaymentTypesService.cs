using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IPaymentTypesService
    {
        Task<IEnumerable<PaymentType>> GetAllAsync();
        Task<PaymentType> GetAsync(long id);
        Task<PaymentType> UpdateAsync(long id, PaymentType obj);
        Task<PaymentType> AddAsync(PaymentType obj);
        Task<PaymentType> DeleteAsync(long id);
        Task<decimal> GetPriceAsync(long id);
    }
}
