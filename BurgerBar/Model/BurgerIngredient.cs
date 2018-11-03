using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class BurgerIngredient
    {
        public long Id { get; set; }

        public Burger Burger { get; set; }

        public Ingredient Ingredient { get; set; }

        public short Position { get; set; }
    }
}
