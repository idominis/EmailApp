using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmailApp.Validation
{
    public class MultipleEmailAddressesAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true; // Consider null as valid; use [Required] for mandatory fields
            }

            var valueString = value.ToString();
            if (valueString == null)
            {
                return false;
            }

            var emails = valueString.Split(',');
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Simplified regex for example

            foreach (var email in emails)
            {
                if (!regex.IsMatch(email.Trim()))
                {
                    return false;
                }
            }

            return true;
        }


        public override string FormatErrorMessage(string name)
        {
            return $"One or more email addresses in the {name} field are not valid.";
        }
    }
}
