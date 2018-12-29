using BurgerBar.Entities;
using System;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class IngredientDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public File Picture { get; set; }

        public string Description { get; set; }

        public IngredientType Type { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
    }
}
