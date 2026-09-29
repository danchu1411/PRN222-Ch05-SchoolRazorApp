using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolRazorApp.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public string FullName { get; set; } = "";

    [BindProperty]
    public string Email { get; set; } = "";

    public string? Message { get; private set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        Message = $"Đã nhận thông tin từ {FullName} ({Email})";
    }
}