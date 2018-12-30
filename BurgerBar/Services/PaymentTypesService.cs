using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class PaymentTypesService : IPaymentTypesService
    {
        protected readonly BurgerBarContext context;
        protected readonly DbSet<PaymentType> dbSet;

        public PaymentTypesService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.PaymentType;
        }

        public async Task<PaymentType> AddAsync(PaymentType obj)
        {
            dbSet.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<PaymentType> DeleteAsync(long id)
        {
            var obj = await GetAsync(id);
            if (obj == null)
            {
                return null;
            }

            dbSet.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<PaymentType> GetAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentType>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.AsEnumerable());
        }

        public async Task<PaymentType> UpdateAsync(long id, PaymentType obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return obj;
        }

        private bool Exists(long id)
        {
            return dbSet.Any(e => e.Id == id);
        }

        public Task<decimal> GetPriceAsync(long id)
        {
            return dbSet
                .Where(b => b.Id == id)
                .Select(b => b.Price)
                .FirstOrDefaultAsync();
        }
    }
}
