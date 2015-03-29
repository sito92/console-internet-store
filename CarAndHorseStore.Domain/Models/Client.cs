using System.ComponentModel.DataAnnotations.Schema;
using CarAndHorseStore.Domain.Models.HelpModels;

namespace CarAndHorseStore.Domain.Models
{
    public class Client : UserBase
    {

        [NotMapped]
        public virtual Cart Cart { get; set; }
        //TODO dodanie jakiejś propercji "Role"?
    }
}
