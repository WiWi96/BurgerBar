using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    public class AddOrderDTO
    {
        public Customer Customer { get; set; }

        public ICollection<OrderedProductDTO> Products { get; set; }

        public long DeliveryTypeId { get; set; }

        public long PaymentTypeId { get; set; }
    }
}
