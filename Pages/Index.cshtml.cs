using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentResultReportCard.Models;
using StudentResultReportCard.Services;

namespace StudentResultReportCard.Pages;

public class IndexModel : PageModel
{
    private readonly StudentResultService _service;
    public IndexModel(StudentResultService service) => _service = service;
    public List<Student> Students { get; set; } = new();
    public int Passed => Students.Count(s => s.Average >= 50);
    public int NeedsImprovement => Students.Count - Passed;
    public double ClassAverage => Students.Count == 0 ? 0 : Students.Average(s => s.Average);
    public void OnGet() => Students = _service.GetAllStudents();
}
