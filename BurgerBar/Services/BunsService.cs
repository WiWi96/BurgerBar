using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class BunsService : IBunsService
    {
        private readonly BurgerBarContext context;
        private readonly DbSet<Bun> dbSet;

        public BunsService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.Bun;
        }

        public async Task<Bun> AddAsync(Bun bun)
        {
            dbSet.Add(bun);
            await context.SaveChangesAsync();
            return bun;
        }

        public async Task<Bun> DeleteAsync(long id)
        {
            var bun = await GetAsync(id);
            if (bun == null)
            {
                return null;
            }

            dbSet.Remove(bun);
            await context.SaveChangesAsync();
            return bun;
        }

        public async Task<Bun> GetAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Bun>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.AsEnumerable());
        }

        public async Task<Bun> UpdateAsync(long id, Bun bun)
        {
            if (bun != null)
            {
                context.Entry(bun).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BunExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return bun;
        }

        private bool BunExists(long id)
        {
            return dbSet.Any(e => e.Id == id);
        }
    }
}
