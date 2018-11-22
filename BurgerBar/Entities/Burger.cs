using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class Burger : Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Code { get; set; }
        
        public Bun Bun { get; set; }

        [Required(ErrorMessageResourceName = "IngredientsRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(1, ErrorMessageResourceName = "IngredientsRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public ICollection<BurgerIngredient> Ingredients { get; set; }

        public CreationType CreationType { get; set; }
    }
}
