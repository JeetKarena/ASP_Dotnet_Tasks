namespace Console_Linq;

public class Task2
{
    //  6. Display employees between age 20 to 30.
    public static List<string> EmployeeAgeBetween20To30()
    {
        using var context = new ApplicationDbContext();
        var q1 = context.Employee.Where(x => x.Age >= 20 && x.Age <= 30).Select(x => x.FirstName + " " + x.Age)
            .ToList();
        return q1;
    }

    // 7. Display female employees
    public static List<string> FemaleEmployees()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.Gender == "femle").Select(x => x.FirstName);
        return new List<string>(result);
    }

    // 8. Display employees with salary more than 35000.
    public static List<string> EmployeeSalaryMoreThan35000()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.Salary > 35000).Select(x => x.FirstName + " " + x.Salary);
        return new List<string>(result);
    }

    // 9. Display employees whose account no is less than 110.
    public static List<string> EmployeeAccountNoLessThan110()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.AccountNo < 110).Select(x => x.FirstName + " " + x.AccountNo);
        return new List<string>(result);
    }

    // 10. Display employees who belongs to either Rajkot or Morbi city.
    public static List<string> EmployeeBelongsToRajkotOrMorbi()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.City == "Rajkot" || x.City == "Morbi")
            .Select(x => x.FirstName + " " + x.City);
        return new List<string>(result);
    }

    // 11. Display employees whose salary is less than 20000.
    public static List<string> EmployeeSalaryLessThan20000()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.Salary < 20000).Select(x => x.FirstName + " " + x.Salary);
        return new List<string>(result);
    }

    // 12. Display employees whose salary is more than equal to 30000 and less than equal to 60000.
    public static List<string> EmployeeSalaryBetween30000To60000()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.Salary >= 30000 && x.Salary <= 60000)
            .Select(x => x.FirstName + " " + x.Salary);
        return new List<string>(result);
    }

    // 13. Display ActNo, FirstName and Amount of employees who belong to Morbi or Ahmedabad or Surat city and Account No greater than 120.
    public static List<string> EmployeeBelongsToMorbiAhmedabadSuratAndAccountNoGreaterThan120()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee
            .Where(x => x.City == "Morbi" || x.City == "Ahmedabad" || x.City == "Surat" && x.AccountNo > 120)
            .Select(x => x.AccountNo + " " + x.FirstName + " " + x.Salary);
        return new List<string>(result);
    }

    // 14. Display male employees of age between 30 to 35 and belongs to Rajkot city.
    public static List<string> MaleEmployeesAgeBetween30To35AndBelongsToRajkot()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.City == "Rajkot" && (x.Age >= 30 && x.Age <= 35))
            .Select(x => x.FirstName);
        return new List<string>(result);
    }

    // 15. Display Unique Cities. (use Distinct())
    public static List<string> UniqueCities()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Select(x => x.City).Distinct();
        return new List<string>(result);
    }

    // 16. Display employees whose joining is between 15/07/2018 to 16/09/2019.
    public static List<string> EmployeeJoiningBetween15July2018To16Sep2019()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee
            .Where(x => x.JoiningDate >= new DateTime(2018, 07, 15) && x.JoiningDate <= new DateTime(2019, 09, 16))
            .Select(x => x.FirstName + " " + x.JoiningDate);
        return new List<string>(result);
    }


    // 17. Display female employees who works in Sales department.
    public static List<string> FemaleEmployeesWorksInSalesDepartment()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.Department == "Sales").Select(x => x.FirstName);
        return new List<string>(result);
    }

    // 18. Display employees with their Age who belong to Rajkot city and more than 35 years old
    public static List<string> EmployeeAgeMoreThan35AndBelongsToRajkot()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.Where(x => x.City == "Rajkot" && x.Age > 35)
            .Select(x => x.FirstName + " " + x.Age);
        return new List<string>(result);
    }
}
