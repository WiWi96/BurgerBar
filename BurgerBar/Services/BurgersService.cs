using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class BurgersService : IBurgersService
    {
        private readonly BurgerBarContext context;
        private readonly DbSet<Burger> dbSet;

        public BurgersService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.Burger;
        }

        public async Task<Burger> AddAsync(Burger burger)
        {
            dbSet.Add(burger);
            foreach(BurgerIngredient burgerIngredient in burger.Ingredients)
            {
                burgerIngredient.Burger = burger;
                context.Set<BurgerIngredient>().Add(burgerIngredient);
                context.Entry(burgerIngredient.Ingredient).State = EntityState.Unchanged;
            }
            context.Entry(burger.Bun).State = EntityState.Unchanged;
            await context.SaveChangesAsync();
            return burger;
        }

        public async Task<Burger> DeleteAsync(long id)
        {
            var burger = await GetAsync(id);
            if (burger == null)
            {
                return null;
            }

            dbSet.Remove(burger);
            await context.SaveChangesAsync();
            return burger;
        }

        public async Task<Burger> GetAsync(long id)
        {
            return await dbSet
                .Include(x => x.Bun)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Burger>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.AsEnumerable());
        }

        public async Task<Burger> UpdateAsync(long id, Burger burger)
        {
            if (burger != null)
            {
                context.Entry(burger).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return burger;
        }

        private bool BurgerExists(long id)
        {
            return dbSet.Any(e => e.Id == id);
        }
    }
}
