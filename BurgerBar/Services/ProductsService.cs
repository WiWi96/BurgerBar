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
        private readonly DbSet<OtherProduct> dbSet;

        public ProductsService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.OtherProduct;
        }

        public async Task<OtherProduct> AddAsync(OtherProduct product)
        {
            dbSet.Add(product);
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

            dbSet.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<OtherProduct> GetAsync(long id)
        {
            return await dbSet.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<IEnumerable<OtherProduct>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.Include(x => x.Type).AsEnumerable());
        }

        public async Task<IEnumerable<OtherProduct>> GetAllInMenuAsync()
        {
            return await Task.FromResult(dbSet
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
            return dbSet.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await Task.FromResult(context.ProductType.AsEnumerable());
        }

        public Task<decimal> GetProductPriceAsync(long id)
        {
            return dbSet
                .Where(b => b.Id == id)
                .Select(b => b.Price)
                .FirstOrDefaultAsync();
        }
    }
}
