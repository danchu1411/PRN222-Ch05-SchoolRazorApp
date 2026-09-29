using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRazorApp.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    [Display(Name = "Sinh viên")]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [Display(Name = "Môn học")]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10")]
    [Column(TypeName = "decimal(4,2)")]
    [Display(Name = "Điểm")]
    public decimal? Grade { get; set; }

    [StringLength(20)]
    [Display(Name = "Học kỳ")]
    public string Semester { get; set; } = "Spring 2026";
}
