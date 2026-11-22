# GradeFlow — Student Result & Report Card Generator

A beginner-friendly ASP.NET Core Razor Pages website built with C# and .NET 10.

## Pages
- Dashboard: class statistics and recently added students
- Add Student: enter student name, ID and marks for five subjects
- Students Records: searchable student directory
- Report Card: individual report card with print option

## Requirements included
- Five subject marks stored in an `int[]`
- `try-catch` exception handling for invalid values
- Separate `GetTotal()`, `GetAverage()` and `GetGrade()` methods
- String interpolation can be seen in the report/validation output and can be used in C# messages
- Marks validation: whole numbers from 0 to 100
- Duplicate student IDs are rejected

## Run in Visual Studio or VS Code
1. Install the .NET 10 SDK.
2. Extract the ZIP file.
3. Open the `StudentResultReportCard` folder in VS Code or Visual Studio.
4. Open a terminal in this folder and run:

```bash
dotnet restore
dotnet run
```

5. Open the localhost URL printed in the terminal (usually `https://localhost:7xxx` or `http://localhost:5xxx`).

## Demo accounts
The website starts with three sample students. New student records are kept in memory and reset when the app stops. No database is used.

## Grade criteria
- A: 80–100
- B: 70–79
- C: 60–69
- F: below 60

Pass status is 50% average or above.
