namespace CarAndHorseStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Client Client { get; set; }
    }
}
