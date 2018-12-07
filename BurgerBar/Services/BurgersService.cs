using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class BurgersService : IBurgersService
    {
        private readonly BurgerBarContext context;
        private readonly DbSet<Burger> dbSet;
        private readonly IBunsService _bunsService;
        private readonly IIngredientsService _ingredientsService;

        public BurgersService(BurgerBarContext context,
            IBunsService bunsService,
            IIngredientsService ingredientsService)
        {
            this.context = context;
            dbSet = context.Burger;
            _bunsService = bunsService;
            _ingredientsService = ingredientsService;
        }

        public async Task<Burger> AddAsync(Burger burger)
        {
            burger.Price = await CalculatePriceAsync(burger);
            dbSet.Add(burger);
            foreach (BurgerIngredient burgerIngredient in burger.Ingredients)
            {
                burgerIngredient.Burger = burger;
                context.Set<BurgerIngredient>().Add(burgerIngredient);
                context.Entry(burgerIngredient.Ingredient).State = EntityState.Unchanged;
            }
            context.Entry(burger.Bun).State = EntityState.Unchanged;
            await context.SaveChangesAsync();
            return burger;
        }

        private async Task<decimal> CalculatePriceAsync(Burger burger)
        {
            if (burger == null)
            {
                throw new NullReferenceException();
            }

            #region Bun price

            decimal bunPrice = await _bunsService.GetBunPriceAsync(burger.Bun.Id);

            if (bunPrice < 0)
            {
                throw new Exception();
            }
            decimal price = bunPrice;

            #endregion

            #region Ingredients price

            foreach (BurgerIngredient bi in burger.Ingredients)
            {
                decimal ingredientPrice = await _ingredientsService.GetIngredientPriceAsync(bi.Ingredient.Id);
                if (ingredientPrice < 0)
                {
                    throw new Exception();
                }
                price += ingredientPrice;
            }

            #endregion

            return price;
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

        public async Task<Burger> GetByCodeAsync(string code)
        {
            return await dbSet
                .Include(x => x.Bun)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .FirstOrDefaultAsync(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
