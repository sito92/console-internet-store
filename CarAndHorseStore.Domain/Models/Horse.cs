using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CarAndHorseStore.Domain.Models
{
    public class Horse : Product
    {
        [Range(1,10)]
        public int BreedId { get; set; }

        [Range(1,2)]
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
