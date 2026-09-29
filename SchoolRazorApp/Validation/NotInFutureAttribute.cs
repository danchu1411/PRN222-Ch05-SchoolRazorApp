using System.ComponentModel.DataAnnotations;

namespace SchoolRazorApp.Validation;

public class NotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext context)
    {
        if (value is DateTime date && date > DateTime.Today)
            return new ValidationResult(
                ErrorMessage ?? "Ngày không được ở tương lai.");

        return ValidationResult.Success;
    }
}
