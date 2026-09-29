8 câu trả lời lý thuyết:
1. Một trang Razor Page gồm mấy file? Mỗi file chịu trách nhiệm gì?
   Một Razor Page thường gồm 2 file:
   - .cshtml: phần giao diện HTML/Razor, chứa form, Tag Helper như asp-for, asp-page.
   - .cshtml.cs: lớp PageModel, chứa dữ liệu, model binding và các handler như OnGet(), OnPost().
     Tài liệu minh họa bằng cặp Contact.cshtml và Contact.cshtml.cs. 29_09_2026___0d77b546-b600-4dde…
2. Chỉ thị @page đặt ở đâu và có tác dụng gì? Bỏ đi thì sao?
   @page đặt ở đầu file .cshtml. Nó biến file .cshtml thành một Razor Page có thể truy cập trực tiếp qua URL. Nếu bỏ @page, trang sẽ không hoạt động như một endpoint Razor Page và khi truy cập sẽ báo lỗi. Tài liệu yêu cầu thử xóa @page để quan sát lỗi rồi khôi phục lại. 29_09_2026___0d77b546-b600-4dde…
3. Handler OnPostDeleteAsync được gọi bằng giá trị nào trong asp-page-handler?
   Giá trị là:
asp-page-handler="Delete"

Theo quy ước Razor Pages, Delete kết hợp với request POST sẽ ánh xạ tới:
OnPostDeleteAsync()

4. Vì sao form tìm kiếm cần SupportsGet = true còn form thêm mới thì không?
   Form tìm kiếm dùng:
method="get"

trong khi [BindProperty] mặc định bind dữ liệu cho POST. Vì vậy phải dùng:
[BindProperty(SupportsGet = true)]

để nhận SearchString và SortOrder từ query string. Nếu thiếu, SearchString luôn rỗng và tìm kiếm không hoạt động. Form thêm mới dùng POST nên [BindProperty] mặc định đã đủ. 29_09_2026___0d77b546-b600-4dde…
5. Sau khi lưu thành công, vì sao phải RedirectToPage() mà không return Page()?
   Sau khi POST thành công nên dùng:
return RedirectToPage();

để chuyển sang một request GET mới. Cách này tránh việc người dùng refresh trang và vô tình gửi lại dữ liệu POST lần nữa. Trong trang Apply, tài liệu lưu thông báo vào TempData rồi RedirectToPage(). Nếu validation không hợp lệ mới dùng return Page() để giữ dữ liệu và hiển thị lỗi. 29_09_2026___0d77b546-b600-4dde…
6. Vì sao thiếu dấu ? ở thuộc tính Student? lại gây lỗi The Student field is required?
   Student trong Enrollment là navigation property. Form thường chỉ gửi StudentId, không gửi cả object Student. Nếu khai báo:
public Student Student { get; set; }

ASP.NET Core coi Student là thuộc tính không được phép null nên validation yêu cầu nó phải có giá trị.
Vì vậy phải khai báo:
public Student? Student { get; set; }
public Course? Course { get; set; }

để navigation property có thể null trong lúc model binding. 29_09_2026___0d77b546-b600-4dde…
7. Kiểm tra dữ liệu ở trình duyệt và ở server khác nhau chỗ nào? Bỏ cái nào cũng được không?
   Validation phía trình duyệt dùng JavaScript, báo lỗi ngay và có thể ngăn request được gửi lên server nên phản hồi nhanh hơn cho người dùng.
Validation phía server chạy sau khi request được gửi lên server và vẫn hoạt động ngay cả khi JavaScript bị tắt. Không được bỏ validation phía server vì người dùng hoặc kẻ tấn công có thể gửi request trực tiếp mà không qua JavaScript. Client validation chủ yếu giúp trải nghiệm nhanh hơn; server validation là bắt buộc. 29_09_2026___0d77b546-b600-4dde…
8. Nêu một tình huống dùng TempData mà không thể thay bằng ViewData.
   Ví dụ sau khi người dùng gửi hồ sơ thành công:
TempData["Success"] =
    $"Đã ghi nhận hồ sơ của {Applicant.FullName}";

return RedirectToPage();

Sau khi redirect sang request mới, trang vẫn đọc được:
@if (TempData["Success"] is string msg)
{
    <div class="alert alert-success">@msg</div>
}

TempData phù hợp vì dữ liệu tồn tại qua request redirect tiếp theo. ViewData chỉ dùng trong request hiện tại nên sau RedirectToPage() sẽ không còn dữ liệu. 29_09_2026___0d77b546-b600-4dde…
