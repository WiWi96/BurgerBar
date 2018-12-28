using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Entities
{
    public class File : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
