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
        private readonly DbSet<Product> dbSet;

        public ProductsService(BurgerBarContext context)
        {
            this.context = context;
            dbSet = context.Product;
        }

        public async Task<Product> AddAsync(Product product)
        {
            dbSet.Add(product);
            context.Entry(product.Type).State = EntityState.Unchanged;
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(long id)
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

        public async Task<Product> GetAsync(long id)
        {
            return await dbSet.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.Include(x => x.Type).AsEnumerable());
        }

        public async Task<Product> UpdateAsync(long id, Product product)
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
    }
}
