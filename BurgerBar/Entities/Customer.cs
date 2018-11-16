using BurgerBar.Resources.Localization;
using System.ComponentModel.DataAnnotations;

namespace BurgerBar.Entities
{
    public class Customer : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "FirstName")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("(\\p{L})+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "LastName")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StringRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [RegularExpression("(\\p{L})+", ErrorMessageResourceName = "NameFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string LastName { get; set; }

        public Address Address { get; set; }

        [Phone(ErrorMessageResourceName = "PhoneFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessageResourceName = "EmailFormatError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }
    }
}
