using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BurgerBar.ViewModels
{
    [DataContract]
    public class AddBurgerDTO
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "bun")]
        public long BunId { get; set; }

        [DataMember(Name = "ingredients")]
        public IEnumerable<long> IngredientIds { get; set; }
    }
}
