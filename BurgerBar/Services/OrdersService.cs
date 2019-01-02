using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public class OrdersService : IOrdersService
    {
        protected readonly BurgerBarContext context;
        protected readonly DbSet<Order> dbSet;
        protected readonly IProductsService productsService;
        protected readonly IDeliveryTypesService deliveryTypesService;
        protected readonly IPaymentTypesService paymentTypesService;

        public OrdersService(BurgerBarContext context,
            IProductsService productsService,
            IDeliveryTypesService deliveryTypesService,
            IPaymentTypesService paymentTypesService)
        {
            this.context = context;
            dbSet = context.Order;
            this.productsService = productsService;
            this.paymentTypesService = paymentTypesService;
            this.deliveryTypesService = deliveryTypesService;
        }

        public async Task<Order> AddAsync(Order obj)
        {
            dbSet.Add(obj);

            obj.Price = await CalculateOrderPriceAsync(obj);
            obj.Date = DateTime.Now;
            context.Entry(obj.PaymentType).State = EntityState.Unchanged;
            context.Entry(obj.DeliveryType).State = EntityState.Unchanged;

            foreach (OrderedProduct op in obj.Products)
            {
                context.Entry(op.Product).State = EntityState.Unchanged;
                context.Entry(op.Product).Reload();
            }

            context.Entry(obj.PaymentType).Reload();
            context.Entry(obj.DeliveryType).Reload();

            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<Order> DeleteAsync(long id)
        {
            var obj = await GetAsync(id);
            if (obj == null)
            {
                return null;
            }

            dbSet.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<Order> GetAsync(long id)
        {
            return await dbSet
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => (x as OtherProduct).Type)
                .Include(x => x.DeliveryType)
                .Include(x => x.PaymentType)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Task.FromResult(dbSet
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .AsEnumerable());
        }

        public async Task<Order> UpdateAsync(long id, Order obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;

                obj.Price = await CalculateOrderPriceAsync(obj);
                context.Entry(obj.PaymentType).State = EntityState.Unchanged;
                context.Entry(obj.DeliveryType).State = EntityState.Unchanged;

                foreach (OrderedProduct op in obj.Products)
                {
                    context.Entry(op.Product).State = EntityState.Unchanged;
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
            return dbSet.Any(e => e.Id == id);
        }

        private async Task<decimal> CalculateOrderPriceAsync(Order order)
        {
            decimal price = 0;

            foreach (OrderedProduct op in order.Products)
            {
                price += await productsService.GetProductPriceAsync(op.Product.Id) * op.Quantity;
            }

            price += await paymentTypesService.GetPriceAsync(order.PaymentType.Id);

            price += await deliveryTypesService.GetPriceAsync(order.DeliveryType.Id);

            return await Task.FromResult(price);
        }
    }
}
