using StudentResultReportCard.Models;

namespace StudentResultReportCard.Services;

public class StudentResultService
{
    // Demo data is stored in memory. It resets when the application stops.
    private static readonly List<Student> students = new()
    {
        new Student { Name = "Ayesha Khan", StudentId = "ST-1001", Marks = new[] { 88, 76, 91, 82, 85 } },
        new Student { Name = "Ali Ahmed", StudentId = "ST-1002", Marks = new[] { 65, 72, 58, 69, 74 } },
        new Student { Name = "Sara Malik", StudentId = "ST-1003", Marks = new[] { 45, 52, 48, 61, 55 } }
    };

    public List<Student> GetAllStudents() => students;

    public Student? GetStudentById(string id) =>
        students.FirstOrDefault(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));

    public bool AddStudent(Student student)
    {
        if (students.Any(s => s.StudentId.Equals(student.StudentId, StringComparison.OrdinalIgnoreCase)))
            return false;

        students.Add(student);
        return true;
    }

    // Required calculation methods
    public int GetTotal(int[] marks)
    {
        int total = 0;
        foreach (int mark in marks)
            total += mark;
        return total;
    }

    public double GetAverage(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;

        return (double)GetTotal(marks) / marks.Length;
    }

    public string GetGrade(double average)
    {
        if (average >= 80) return "A";
        else if (average >= 70) return "B";
        else if (average >= 60) return "C";
        else return "F";
    }
}
