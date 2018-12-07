using BurgerBar.Entities;
using System;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }
    }
}
