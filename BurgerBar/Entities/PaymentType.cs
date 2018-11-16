using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class PaymentType : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsCOD { get; set; }
    }
}
