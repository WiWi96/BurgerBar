using BurgerBar.Resources.Localization;
using System.ComponentModel.DataAnnotations;

namespace BurgerBar.Entities
{
    public class Address : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Street")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("^(\\p{Nd}|\\p{L})(\\p{Nd}|\\p{L}|[ \\-&,.])+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Street { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "ApartmentNumber")]
        [StringLength(8, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ApartmentNumber { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "HouseNumber")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(8, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string HouseNumber { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "PostalCode")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(10, MinimumLength = 4, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string PostalCode { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "Town")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("^(\\p{Nd}|\\p{L})(\\p{Nd}|\\p{L}|[ \\-&,.])+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Town { get; set; }
    }
}