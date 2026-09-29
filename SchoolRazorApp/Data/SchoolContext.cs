using Microsoft.EntityFrameworkCore;
using SchoolRazorApp.Models;

namespace SchoolRazorApp.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.StudentCode)
            .IsUnique();

        modelBuilder.Entity<Course>()
            .HasIndex(c => c.CourseCode)
            .IsUnique();

        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new
            {
                e.StudentId,
                e.CourseId,
                e.Semester
            })
            .IsUnique();

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                CourseId = 1,
                CourseCode = "PRN212",
                Title = "Basic Cross-Platform Programming With .NET",
                Credits = 3
            },
            new Course
            {
                CourseId = 2,
                CourseCode = "PRN222",
                Title = "Advanced Cross-Platform Programming With .NET",
                Credits = 3
            },
            new Course
            {
                CourseId = 3,
                CourseCode = "PRN232",
                Title = "Building Cross-Platform Back-End With .NET",
                Credits = 3
            },
            new Course
            {
                CourseId = 4,
                CourseCode = "SWD392",
                Title = "Software Architecture and Design",
                Credits = 3
            },
            new Course
            {
                CourseId = 5,
                CourseCode = "PWD301",
                Title = "Web Design",
                Credits = 3
            }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                StudentCode = "DE160001",
                LastName = "Nguyễn Văn",
                FirstName = "An",
                Email = "andv@fpt.edu.vn",
                Phone = "0905000001",
                EnrollmentDate = new DateTime(2024, 9, 5)
            },
            new Student
            {
                StudentId = 2,
                StudentCode = "DE160002",
                LastName = "Trần Thị",
                FirstName = "Bình",
                Email = "binhtt@fpt.edu.vn",
                Phone = "0905000002",
                EnrollmentDate = new DateTime(2024, 9, 5)
            },
            new Student
            {
                StudentId = 3,
                StudentCode = "DE160003",
                LastName = "Lê Hoàng",
                FirstName = "Cường",
                Email = "cuonglh@fpt.edu.vn",
                Phone = "0905000003",
                EnrollmentDate = new DateTime(2024, 9, 5)
            },
            new Student
            {
                StudentId = 4,
                StudentCode = "DE160004",
                LastName = "Phạm Thị",
                FirstName = "Dung",
                Email = "dungpt@fpt.edu.vn",
                Phone = "0905000004",
                EnrollmentDate = new DateTime(2025, 1, 8)
            },
            new Student
            {
                StudentId = 5,
                StudentCode = "DE160005",
                LastName = "Võ Quốc",
                FirstName = "Trình",
                Email = "trinhvq@fpt.edu.vn",
                Phone = "0905000005",
                EnrollmentDate = new DateTime(2025, 1, 8)
            },
            new Student
            {
                StudentId = 6,
                StudentCode = "DC160006",
                LastName = "Đặng Minh",
                FirstName = "Hải",
                Email = "haidm@fpt.edu.vn",
                Phone = "0905000006",
                EnrollmentDate = new DateTime(2025, 5, 12)
            },
            new Student
            {
                StudentId = 7,
                StudentCode = "DC160007",
                LastName = "Hoàng Thị",
                FirstName = "Lan",
                Email = "lanht@fpt.edu.vn",
                Phone = "0905000007",
                EnrollmentDate = new DateTime(2025, 5, 12)
            },
            new Student
            {
                StudentId = 8,
                StudentCode = "DS160008",
                LastName = "Bùi Xuân",
                FirstName = "Nam",
                Email = "nambx@fpt.edu.vn",
                Phone = "0905000008",
                EnrollmentDate = new DateTime(2025, 9, 3)
            },
            new Student
            {
                StudentId = 9,
                StudentCode = "DS160009",
                LastName = "Ngô Thị",
                FirstName = "Oanh",
                Email = "oanhnt@fpt.edu.vn",
                Phone = "0905000009",
                EnrollmentDate = new DateTime(2025, 9, 3)
            },
            new Student
            {
                StudentId = 10,
                StudentCode = "DE160010",
                LastName = "Đỗ Văn",
                FirstName = "Phúc",
                Email = "phucdv@fpt.edu.vn",
                Phone = "0905000010",
                EnrollmentDate = new DateTime(2026, 1, 6)
            },
            new Student
            {
                StudentId = 11,
                StudentCode = "DE160011",
                LastName = "Lý Thị",
                FirstName = "Quyên",
                Email = "quyenlt@fpt.edu.vn",
                Phone = "0905000011",
                EnrollmentDate = new DateTime(2026, 1, 6)
            },
            new Student
            {
                StudentId = 12,
                StudentCode = "DE160012",
                LastName = "Trương Văn",
                FirstName = "Sơn",
                Email = "sontv@fpt.edu.vn",
                Phone = "0905000012",
                EnrollmentDate = new DateTime(2026, 1, 6)
            }
        );
    }
}