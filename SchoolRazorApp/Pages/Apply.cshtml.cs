using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolRazorApp.Models;

namespace SchoolRazorApp.Pages;

public class ApplyModel : PageModel
{
    [BindProperty]
    public Applicant Applicant { get; set; } = new();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        TempData["Success"] =
            $"Đã ghi nhận hồ sơ của {Applicant.FullName}";

        return RedirectToPage();
    }
}