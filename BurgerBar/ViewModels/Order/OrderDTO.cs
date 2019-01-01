using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int ProductsCount { get; set; }
        public decimal Price { get; set; }
    }
}
