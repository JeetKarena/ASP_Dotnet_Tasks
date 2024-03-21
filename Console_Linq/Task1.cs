using System.Globalization;
using Microsoft.Extensions.Logging;

namespace Console_Linq;

//LINQ Queries on Projection operators
public class Task1
{
    // 1. Display data of all employees.
    public static List<string> GetAllEmployeeNames()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Select(x => x.LastName + " " + x.FirstName).ToList();
        return q1;
    }
    // 2 . Select ActNo, FirstName and Salary of all employees to a new class and display it.

    public static List<string> GetEmployeeDetails()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Select(x => new Employee
        {
            AccountNo = x.AccountNo,
            FirstName = x.FirstName,
            Salary = x.Salary
        }).ToList();
        var result= q1.Select(x => x.AccountNo + " " + x.FirstName + " " + x.Salary).ToList();
        return result;
    }

    // 3. Display data in following format => {Anil} works in {Admin} Department.
    public static List<string> FirstNameAndDepartment()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Select(x => x.FirstName + " works in " + x.Department + " Department.").ToList();
        return q1;
    }

    // 4. Select Employee Full Name, Email and Department as anonymous and display it.
    public static List<string> EmployeeFullNameEmailDepartment()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Select(x => new
        {
            FullName = x.FirstName + " " + x.LastName,
            Email = x.Email,
            Department = x.Department
        }).ToList();
        var q2 = q1.Select(x => x.FullName + " " + x.Email + " " + x.Department).ToList();
        return q2;
    }
    
    // 5. Display employees with their joining date.
    public static List<string> EmployeeJoiningDate()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Select(x => x.FirstName + " " + x.JoiningDate).ToList();
        return q1;
    }
}