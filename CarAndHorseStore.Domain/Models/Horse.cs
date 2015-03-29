using System.Data.Entity;

namespace CarAndHorseStore.Domain.Models
{
    public class Horse : Product
    {

        public int BreedId { get; set; }
        public int SexId { get; set; }
        public Breed Breed { get; set; }


        public Sex Sex { get; set; }

    }
}
