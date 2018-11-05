using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class Ingredient
    {
        public long Id { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("(\\p{L})+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Description")]
        [StringLength(300, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Description { get; set; }

        public IngredientType Type { get; set; }

        public string Picture { get; set; }
    }
}
