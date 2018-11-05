using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
