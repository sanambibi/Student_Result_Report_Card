using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentResultReportCard.Models;
using StudentResultReportCard.Services;

namespace StudentResultReportCard.Pages;

public class AddStudentModel : PageModel
{
    private readonly StudentResultService _service;
    public AddStudentModel(StudentResultService service) => _service = service;

    [BindProperty] public string StudentName { get; set; } = "";
    [BindProperty] public string StudentId { get; set; } = "";
    [BindProperty] public List<string> MarkInputs { get; set; } = new();

    public string Message { get; set; } = "";
    public bool IsSuccess { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(StudentName) || string.IsNullOrWhiteSpace(StudentId))
                throw new ArgumentException("Please enter both the student name and student ID.");

            if (MarkInputs == null || MarkInputs.Count != 5)
                throw new ArgumentException("Please enter marks for all five subjects.");

            int[] marks = new int[5];
            for (int i = 0; i < 5; i++)
            {
                if (!int.TryParse(MarkInputs[i], out marks[i]))
                    throw new FormatException($"Subject {i + 1}: please enter a valid whole number.");

                if (marks[i] < 0 || marks[i] > 100)
                    throw new ArgumentOutOfRangeException(nameof(MarkInputs), $"Subject {i + 1}: marks must be between 0 and 100.");
            }

            var student = new Student { Name = StudentName.Trim(), StudentId = StudentId.Trim(), Marks = marks };
            if (!_service.AddStudent(student))
                throw new ArgumentException("This student ID already exists. Please use a unique ID.");

            return RedirectToPage("/Report", new { id = student.StudentId });
        }
        catch (Exception ex)
        {
            Message = ex.Message;
            IsSuccess = false;
            return Page();
        }
    }
}
