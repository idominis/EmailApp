using System.Collections.Generic;
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

            if (value is List<string> emailList)
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); // Simplified regex for example

                foreach (var email in emailList)
                {
                    if (!regex.IsMatch(email.Trim()))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"One or more email addresses in the {name} field are not valid.";
        }
    }
}
