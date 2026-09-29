using System.ComponentModel.DataAnnotations;

namespace SchoolRazorApp.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mã sinh viên")]
    [StringLength(20)]
    [RegularExpression(@"^(DE|DC|DS)\d{6}$",
        ErrorMessage = "Mã phải có dạng DE160123")]
    [Display(Name = "Mã sinh viên")]
    public string StudentCode { get; set; } = default!;

    [Required, StringLength(50)]
    [Display(Name = "Họ và tên đệm")]
    public string LastName { get; set; } = default!;

    [Required, StringLength(30)]
    [Display(Name = "Tên")]
    public string FirstName { get; set; } = default!;

    [Display(Name = "Họ và tên")]
    public string FullName => $"{LastName} {FirstName}";

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = default!;

    [Phone, StringLength(20)]
    [Display(Name = "Điện thoại")]
    public string? Phone { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
        ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày nhập học")]
    public DateTime EnrollmentDate { get; set; } = DateTime.Today;

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
}
