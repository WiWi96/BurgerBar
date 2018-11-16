using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class OrdersService : IOrdersService
    {
        protected readonly BurgerBarContext context;
        protected readonly DbSet<Order> dbSet;

        public OrdersService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.Order;
        }

        public async Task<Order> AddAsync(Order obj)
        {
            dbSet.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Order> DeleteAsync(long id)
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

        public async Task<Order> GetAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.AsEnumerable());
        }

        public async Task<Order> UpdateAsync(long id, Order obj)
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
    }
}
