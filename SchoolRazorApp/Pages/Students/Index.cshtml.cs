using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolRazorApp.Data;
using SchoolRazorApp.Helpers;
using SchoolRazorApp.Models;

namespace SchoolRazorApp.Pages.Students;

public class IndexModel : PageModel
{
    private readonly SchoolContext _context;
    private readonly IConfiguration _configuration;

    public IndexModel(
        SchoolContext context,
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public PaginatedList<Student> Students { get; private set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SortOrder { get; set; }

    public string NameSort =>
        string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";

    public string DateSort =>
        SortOrder == "date" ? "date_desc" : "date";

    public string CodeSort =>
        SortOrder == "code" ? "code_desc" : "code";

    public async Task OnGetAsync(int? pageIndex)
    {
        var pageSize =
            _configuration.GetValue("SiteSettings:PageSize", 5);

        IQueryable<Student> query =
            _context.Students.Include(s => s.Enrollments);

        if (!string.IsNullOrWhiteSpace(SearchString))
        {
            query = query.Where(s =>
                s.LastName.Contains(SearchString) ||
                s.FirstName.Contains(SearchString) ||
                s.StudentCode.Contains(SearchString) ||
                s.Email.Contains(SearchString));
        }

        query = SortOrder switch
        {
            "name_desc" => query
                .OrderByDescending(s => s.LastName)
                .ThenByDescending(s => s.FirstName),

            "date" => query
                .OrderBy(s => s.EnrollmentDate),

            "date_desc" => query
                .OrderByDescending(s => s.EnrollmentDate),

            "code" => query
                .OrderBy(s => s.StudentCode),

            "code_desc" => query
                .OrderByDescending(s => s.StudentCode),

            _ => query
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
        };

        Students = await PaginatedList<Student>.CreateAsync(
            query.AsNoTracking(),
            pageIndex ?? 1,
            pageSize);
    }
}