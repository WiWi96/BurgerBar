using System;
using System.Collections.Generic;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class BurgerDTO : ProductDTO
    {
        public string Code { get; set; }

        public BunDTO Bun { get; set; }

        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}
