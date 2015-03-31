using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models.HelpModels
{
    public class ComapreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Color { get; set; }
        public string Breed { get; set; }
        public string Brand { get; set; }
        public string Bodytype { get; set; }

        public int Cylinderamount { get; set; }

        public float Enginecapacity { get; set; }

        public float Price { get; set; }
    }
}
