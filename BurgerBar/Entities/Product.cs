using BurgerBar.Resources.Localization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerBar.Entities
{
    public class Product : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(20, MinimumLength = 4, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("(\\p{L})+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsInMenu { get; set; }

        public CreationType CreationType { get; set; }
    }
}