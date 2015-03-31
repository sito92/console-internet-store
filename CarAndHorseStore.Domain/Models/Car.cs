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
        public virtual Brand Brand { get; set; }

        public virtual BodyType BodyType { get; set; }

        public virtual EngineType EngineType { get; set; } 

        public override string ToString()
        {
            var result = base.ToString();             
            return result+" " +Brand.Name+" "+BodyType.Name+" "+EngineType.CylinderAmount.ToString()+ " " + EngineType.EngineCapacity.ToString();
            
        }

    }
}
