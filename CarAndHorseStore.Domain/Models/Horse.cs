using System.Data.Entity;

namespace CarAndHorseStore.Domain.Models
{
    public class Horse : Product
    {

        public int BreedId { get; set; }
        public int SexId { get; set; }
        public virtual Breed Breed { get; set; }


        public virtual Sex Sex { get; set; }

        public override string ToString()
        {
            var result = base.ToString();
            return result + " " + Breed.Name + " " + Sex.Name;

        }

    }
}
