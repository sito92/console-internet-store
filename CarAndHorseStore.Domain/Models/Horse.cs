using System.Data.Entity;

namespace CarAndHorseStore.Domain.Models
{
    public class Horse : Product
    {
        public string Name { get; set; }

        public Breed Breed { get; set; }

        public Color Color { get; set; }

        public Sex Sex { get; set; }

    }
}
