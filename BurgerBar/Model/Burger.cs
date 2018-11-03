using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class Burger : Product
    {
        public string Number { get; set; }

        public Bun Bun { get; set; }

        public ICollection<BurgerIngredient> Ingredients { get; set; }
    }
}
