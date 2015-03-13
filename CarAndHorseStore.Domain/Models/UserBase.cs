using CarAndHorseStore.Domain.Interfaces;

namespace CarAndHorseStore.Domain.Models
{
    public class UserBase : IUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EMail { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
