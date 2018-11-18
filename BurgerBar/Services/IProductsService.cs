using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(long id);
        Task<Product> UpdateAsync(long id, Product product);
        Task<Product> AddAsync(Product burger);
        Task<Product> DeleteAsync(long id);
        Task<IEnumerable<ProductType>> GetProductTypes();
    }
}
