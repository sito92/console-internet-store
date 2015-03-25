using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models.HelpModels
{
    public class Cart
    {
        private const string EmptyCart = "Koszyk jest pusty";
        public List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            if (Products==null||Products.Count==0)
            {
                return EmptyCart;
            }
            string cart = "Zawartość koszyka:\n";
            foreach (var product in Products)
            {
                cart += product.Id + product.Description +"\n";
            }
            return cart;

        }
    }
}
