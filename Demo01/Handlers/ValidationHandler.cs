using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace Demo01.Handlers
{
    public static class ValidationHandler
    {
        public static void IsRequired(this ModelStateDictionary modelState, string formFieldValue, string formFieldName)
        {
            if (string.IsNullOrWhiteSpace(formFieldValue))
            {
                modelState.AddModelError(formFieldName, $"Le {formFieldName} est obligatoire...");
            }
        }

        public static void HasMinLenght(this ModelStateDictionary modelState, string formFieldValue, string formFieldName, int minCharacter)
        {
            if (formFieldValue is not null && formFieldValue.Length < minCharacter)
            {
                modelState.AddModelError(formFieldName, $"Le {formFieldName} doit avoir au minimum {minCharacter} caractères.");
            }
        }
        public static void HasMaxLenght(this ModelStateDictionary modelState, string formFieldValue, string formFieldName, int maxCharacter)
        {
            if (formFieldValue is not null && formFieldValue.Length > maxCharacter)
            {
                modelState.AddModelError(formFieldName, $"Le {formFieldName} doit avoir au maximum {maxCharacter} caractères.");
            }
        }

        public static void IsMatched(this ModelStateDictionary modelState, string formFieldValue, string formFieldName, string pattern, string? message)
        {
            message ??= "Le {0} n'est pas au bon format.";
            if (formFieldValue is not null && !Regex.IsMatch(formFieldValue, pattern))
            {
                modelState.AddModelError(formFieldName, string.Format(message, formFieldName));
            }
        }
    }
}
