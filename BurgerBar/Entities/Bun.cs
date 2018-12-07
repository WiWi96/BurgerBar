using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class Bun : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("^(\\p{Nd}|\\p{L})(\\p{Nd}|\\p{L}|[ \\-&,.])+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Description")]
        [StringLength(300, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Description { get; set; }

        public bool Active { get; set; } = true;

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessageResourceName = "PriceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public decimal Price { get; set; }

        public File TopPicture { get; set; }

        public File BottomPicture { get; set; }
    }
}
