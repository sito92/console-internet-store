namespace CarAndHorseStore.Models
{
    public class ProductList
    {
        public int Id { get; set; }

        //public Product Product { get; set; }

        public Order Order { get; set; }

        public int Amount { get; set; }
    }
}
