using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class Order : BaseEntity
    {
        [Display(ResourceType = typeof(Labels), Name = "Customer")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public Customer Customer { get; set; }

        [Required(ErrorMessageResourceName = "ProductsRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(1, ErrorMessageResourceName = "ProductsRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public ICollection<OrderedProduct> Products { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "DeliveryType")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public DeliveryType DeliveryType { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "PaymentType")]
        [Required(ErrorMessageResourceName = "ReferenceRequiredError", ErrorMessageResourceType = typeof(ErrorMessages))]
        public PaymentType PaymentType { get; set; }

        public DateTime Date { get; set; }
    }
}
