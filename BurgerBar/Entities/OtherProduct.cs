using BurgerBar.Resources.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class OtherProduct : Product
    {
        [Display(ResourceType = typeof(Labels), Name = "ProductType")]
        public ProductType Type { get; set; }
    }
}
