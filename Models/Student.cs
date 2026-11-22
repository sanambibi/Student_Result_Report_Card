namespace StudentResultReportCard.Models;

public class Student
{
    public string Name { get; set; } = "";
    public string StudentId { get; set; } = "";
    public int[] Marks { get; set; } = new int[5];

    public int Total => Marks.Sum();
    public double Average => Marks.Length == 0 ? 0 : Marks.Average();
    public string Grade => Average >= 80 ? "A" :
                           Average >= 70 ? "B" :
                           Average >= 60 ? "C" : "F";
    public string Result => Average >= 50 ? "PASS" : "NEEDS IMPROVEMENT";
}
