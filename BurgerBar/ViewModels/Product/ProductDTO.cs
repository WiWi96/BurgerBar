using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsInMenu { get; set; }

        public bool Active { get; set; }
    }
}
