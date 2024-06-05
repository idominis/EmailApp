using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmailApp.Validation
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var email = value as string;
            if (string.IsNullOrEmpty(email))
            {
                return false; // Consider null or empty string as invalid use [Required] for mandatory field
            }

            // More comprehensive email regex pattern
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // Ensure the email has no consecutive dots
            if (email.Contains(".."))
            {
                return false;
            }

            return regex.IsMatch(email);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name} field is not a valid email address.";
        }
    }
}
