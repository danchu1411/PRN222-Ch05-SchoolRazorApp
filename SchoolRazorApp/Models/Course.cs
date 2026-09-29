using System.ComponentModel.DataAnnotations;

namespace SchoolRazorApp.Models;

public class Course
{
    public int CourseId { get; set; }

    [Required, StringLength(10)]
    [Display(Name = "Mã môn")]
    public string CourseCode { get; set; } = default!;

    [Required, StringLength(150)]
    [Display(Name = "Tên môn học")]
    public string Title { get; set; } = default!;

    [Range(1, 10, ErrorMessage = "Số tín chỉ từ 1 đến 10")]
    [Display(Name = "Số tín chỉ")]
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
}