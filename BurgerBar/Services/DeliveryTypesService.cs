using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class DeliveryTypesService : IDeliveryTypesService
    {
        protected readonly BurgerBarContext context;
        protected readonly DbSet<DeliveryType> dbSet;

        public DeliveryTypesService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.DeliveryType;
        }

        public async Task<DeliveryType> AddAsync(DeliveryType obj)
        {
            dbSet.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DeliveryType> DeleteAsync(long id)
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

        public async Task<DeliveryType> GetAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<DeliveryType>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.AsEnumerable());
        }

        public async Task<DeliveryType> UpdateAsync(long id, DeliveryType obj)
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
