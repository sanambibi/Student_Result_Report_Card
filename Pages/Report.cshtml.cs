using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentResultReportCard.Models;
using StudentResultReportCard.Services;

namespace StudentResultReportCard.Pages;

public class ReportModel : PageModel
{
    private readonly StudentResultService _service;
    public ReportModel(StudentResultService service) => _service = service;
    public Student? Student { get; set; }
    public int Total { get; set; }
    public double Average { get; set; }

    public IActionResult OnGet(string id)
    {
        Student = _service.GetStudentById(id ?? "");
        if (Student != null)
        {
            Total = _service.GetTotal(Student.Marks);
            Average = _service.GetAverage(Student.Marks);
        }
        return Page();
    }
}
