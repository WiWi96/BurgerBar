using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IIngredientsService
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<Ingredient> GetAsync(long id);
        Task<Ingredient> UpdateAsync(long id, Ingredient obj);
        Task<Ingredient> AddAsync(Ingredient obj);
        Task<Ingredient> DeleteAsync(long id);
        Task<IEnumerable<IngredientType>> GetIngredientTypes();
    }
}
