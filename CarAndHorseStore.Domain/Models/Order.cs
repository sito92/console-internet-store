namespace CarAndHorseStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
