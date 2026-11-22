using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentResultReportCard.Models;
using StudentResultReportCard.Services;

namespace StudentResultReportCard.Pages;

public class StudentsModel : PageModel
{
    private readonly StudentResultService _service;
    public StudentsModel(StudentResultService service) => _service = service;
    public List<Student> Students { get; set; } = new();
    public void OnGet() => Students = _service.GetAllStudents();
}
