using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models
{
    public class Car : Product
    {
        public int BrandId { get; set; }
        public int BodyTypeId { get; set; }
        
        public int EngineTypeId { get; set; }
        public Brand Brand { get; set; }

        public BodyType BodyType { get; set; }

        

        public EngineType EngineType { get; set; }

    }
}
