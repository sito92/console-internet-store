using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models.HelpModels
{
    public class Cart
    {
        private const string emptyCart = "Koszyk jest pusty";
        private const string cartContent = "Zawartość koszyka:\n";
        public List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            if (Products==null || Products.Count==0)
            {
                return emptyCart;
            }

            string cart = cartContent;
            foreach (var product in Products)
            {
                cart += product.Id + product.Description +"\n";
                //czemu nie działa?!
                //cart += product.ToString() + "\n";
            }
            return cart;

        }
    }
}
