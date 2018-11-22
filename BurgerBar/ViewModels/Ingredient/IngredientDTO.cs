using System;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class IngredientDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public long TypeId { get; set; }

        public decimal Price { get; set; }
    }
}
