using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }

        public BodyType BodyType { get; set; }

        public Brand Brand { get; set; }

        public Color Color { get; set; }

        public EngineType EngineType { get; set; }

    }
}
