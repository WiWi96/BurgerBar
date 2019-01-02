using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<OtherProduct>> GetAllAsync();
        Task<OtherProduct> GetAsync(long id);
        Task<OtherProduct> UpdateAsync(long id, OtherProduct product);
        Task<OtherProduct> AddAsync(OtherProduct burger);
        Task<OtherProduct> DeleteAsync(long id);
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task<IEnumerable<OtherProduct>> GetAllInMenuAsync();
        Task<decimal> GetProductPriceAsync(long id);
        Task<Product> SetProductInMenu(long id, bool inMenu);
    }
}
