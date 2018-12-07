
using System;

namespace BurgerBar.ViewModels
{
    [Serializable]
    public class BunDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string TopPicture { get; set; }

        public string BottomPicture { get; set; }
    }
}
