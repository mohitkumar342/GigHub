using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isConverted = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.None,
                out dateTime);

            return (isConverted && dateTime > DateTime.Now);
        }
    }
}