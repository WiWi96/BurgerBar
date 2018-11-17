using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    public class IngredientDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
