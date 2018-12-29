
using BurgerBar.Entities;
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

        public File TopPicture { get; set; }

        public File BottomPicture { get; set; }

        public bool Active { get; set; }
    }
}
