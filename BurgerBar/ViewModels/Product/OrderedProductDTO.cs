using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    public class OrderedProductDTO
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
