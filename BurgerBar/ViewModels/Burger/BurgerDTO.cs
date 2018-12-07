using System;
using System.Collections.Generic;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class BurgerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Code { get; set; }

        public BunDTO Bun { get; set; }

        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}
