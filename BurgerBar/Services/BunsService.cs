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

            if (bun.BottomPicture != null)
            {
                context.Entry(bun.BottomPicture).State = EntityState.Unchanged;
            }
            if (bun.TopPicture != null)
            {
                context.Entry(bun.TopPicture).State = EntityState.Unchanged;
            }

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
            return await dbSet
                .Include(x => x.BottomPicture)
                .Include(x => x.TopPicture)
                .FirstOrDefaultAsync(x => x.Id == id);
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

                if (bun.BottomPicture != null)
                {
                    context.Entry(bun.BottomPicture).State = EntityState.Unchanged;
                }
                if (bun.TopPicture != null)
                {
                    context.Entry(bun.TopPicture).State = EntityState.Unchanged;
                }

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

        public Task<decimal> GetBunPriceAsync(long id)
        {
            return dbSet
                .Where(b => b.Id == id)
                .Select(b => b.Price)
                .FirstOrDefaultAsync();
        }
    }
}
