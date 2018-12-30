using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class DeliveryType : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("^(\\p{Nd}|\\p{L})(\\p{Nd}|\\p{L}|[ \\-&,.])+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Provider")]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("^(\\p{Nd}|\\p{L})(\\p{Nd}|\\p{L}|[ \\-&,.])+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Provider { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsCOD { get; set; } = false;
    }
}
