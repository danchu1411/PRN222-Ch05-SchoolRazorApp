using System.ComponentModel.DataAnnotations;
using SchoolRazorApp.Validation;

namespace SchoolRazorApp.Models;

public class Applicant
{
    [Required(ErrorMessage = "Vui lòng nhập họ tên")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Họ tên từ 3 đến 100 ký tự")]
    [Display(Name = "Họ và tên")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = "";

    [NotInFuture(ErrorMessage = "Ngày sinh không được ở tương lai")]
    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime BirthDate { get; set; } = DateTime.Today;
}
