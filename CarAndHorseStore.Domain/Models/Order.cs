namespace CarAndHorseStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public ProductList ProductList { get; set; }

    }
}
