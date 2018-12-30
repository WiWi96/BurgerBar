using BurgerBar.Entities;
using System;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class OtherProductDTO : ProductDTO
    {
        public ProductType Type { get; set; }
    }
}
