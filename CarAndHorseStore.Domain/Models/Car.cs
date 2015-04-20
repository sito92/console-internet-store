using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models
{
    public class Car : Product
    {
        [Range(1,7)]
        public int BrandId { get; set; }

        [Range(1,5)]
        public int BodyTypeId { get; set; }
        
        [Range(1,21)]
        public int EngineTypeId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual BodyType BodyType { get; set; }

        public virtual EngineType EngineType { get; set; } 

        public override string ToString()
        {
            var result = base.ToString();             
            return result+" " +Brand.Name+" "+BodyType.Name+" "+EngineType.CylinderAmount+ " " + EngineType.EngineCapacity;   
        }

    }
}
