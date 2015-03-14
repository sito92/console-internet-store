using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models
{
    public abstract class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        //public QRCode QRCode?

        public float Price { get; set; }
    }
}
