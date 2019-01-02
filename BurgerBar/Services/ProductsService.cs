using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class ProductsService : IProductsService
    {
        private readonly BurgerBarContext context;
        private readonly DbSet<OtherProduct> otherProductsSet;
        private readonly DbSet<Product> productsSet;

        public ProductsService(BurgerBarContext context)
        {
            this.context = context;
            otherProductsSet = context.OtherProduct;
            productsSet = context.Product;
        }

        public async Task<OtherProduct> AddAsync(OtherProduct product)
        {
            otherProductsSet.Add(product);
            context.Entry(product.Type).State = EntityState.Unchanged;
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<OtherProduct> DeleteAsync(long id)
        {
            var product = await GetAsync(id);
            if (product == null)
            {
                return null;
            }

            otherProductsSet.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<OtherProduct> GetAsync(long id)
        {
            return await otherProductsSet.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<IEnumerable<OtherProduct>> GetAllAsync()
        {
            return await Task.FromResult(otherProductsSet.Include(x => x.Type).AsEnumerable());
        }

        public async Task<IEnumerable<OtherProduct>> GetAllInMenuAsync()
        {
            return await Task.FromResult(otherProductsSet
                .Where(x => x.IsInMenu && x.Active)
                .Include(x => x.Type)
                .AsEnumerable());
        }

        public async Task<OtherProduct> UpdateAsync(long id, OtherProduct product)
        {
            if (product != null)
            {
                context.Entry(product).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return product;
        }

        private bool ProductExists(long id)
        {
            return otherProductsSet.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await Task.FromResult(context.ProductType.AsEnumerable());
        }

        public Task<decimal> GetProductPriceAsync(long id)
        {
            return otherProductsSet
                .Where(b => b.Id == id)
                .Select(b => b.Price)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> SetProductInMenu(long id, bool inMenu)
        {
            var product = await productsSet.FindAsync(id);
            product.IsInMenu = inMenu;

            context.Entry(product).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }
    }
}
