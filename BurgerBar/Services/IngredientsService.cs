using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class IngredientsService : IIngredientsService
    {
        protected readonly BurgerBarContext context;
        protected readonly DbSet<Ingredient> ingredientsSet;
        protected readonly DbSet<IngredientType> ingredientTypesSet;

        public IngredientsService(BurgerBarContext context)
        {
            this.context = context;
            ingredientsSet = context.Ingredient;
            ingredientTypesSet = context.IngredientType;
        }

        public async Task<Ingredient> AddAsync(Ingredient obj)
        {
            ingredientsSet.Add(obj);
            context.Entry(obj.Type).State = EntityState.Unchanged;

            if (obj.Picture != null)
            {
                context.Entry(obj.Picture).State = EntityState.Unchanged;
            }

            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Ingredient> DeleteAsync(long id)
        {
            var obj = await GetAsync(id);
            if (obj == null)
            {
                return null;
            }

            ingredientsSet.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Ingredient> GetAsync(long id)
        {
            return await ingredientsSet
                .Include(x => x.Type)
                .Include(x => x.Picture)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await Task.FromResult(ingredientsSet.Include(x => x.Type).AsEnumerable());
        }

        public async Task<IEnumerable<Ingredient>> GetAllAvailableAsync()
        {
            return await Task.FromResult(ingredientsSet
                                .Where(x => x.Active)
                                .Include(x => x.Type)
                                .Include(x => x.Picture)
                                .AsEnumerable());
        }

        public async Task<Ingredient> UpdateAsync(long id, Ingredient obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;
                context.Entry(obj.Type).State = EntityState.Unchanged;

                if (obj.Picture != null)
                {
                    context.Entry(obj.Picture).State = EntityState.Unchanged;
                }

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
            return ingredientsSet.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<IngredientType>> GetIngredientTypes()
        {
            return await Task.FromResult(ingredientTypesSet.AsEnumerable());
        }

        public Task<decimal> GetIngredientPriceAsync(long id)
        {
            return ingredientsSet
                .Where(b => b.Id == id)
                .Select(b => b.Price)
                .FirstOrDefaultAsync();
        }
    }
}
