using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Domain.Models;

namespace CarAndHorseStore.Core.System.Helpers
{
    public static class ValidationHelper
    {
        public static bool isValid(Product prod)
        {
            var isProdValid = Validator.TryValidateObject(prod, new ValidationContext(prod, null, null),
                new List<ValidationResult>(), true);

            return isProdValid;
        }
    }
}
