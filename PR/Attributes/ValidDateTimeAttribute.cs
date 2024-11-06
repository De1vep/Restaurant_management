using System.ComponentModel.DataAnnotations;

namespace PR.Validations;
public class ValidDateTimeAttribute : ValidationAttribute
{
    public ValidDateTimeAttribute()
    {
        ErrorMessage = "The value '{0}' is invalid.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || DateTime.TryParse(value.ToString(), out _))
        {
            return ValidationResult.Success;
        }

        // Show custom error message if invalid
        return new ValidationResult(string.Format(ErrorMessage, value));
    }
}
