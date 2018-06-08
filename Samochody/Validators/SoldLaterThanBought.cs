using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Samochody.Models;

namespace Samochody.Validators
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SoldLaterThanBought : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = (Car)value;
            if (model != null)
                return (model.Sold > model.Bought);
            return true;
        }
    }
}