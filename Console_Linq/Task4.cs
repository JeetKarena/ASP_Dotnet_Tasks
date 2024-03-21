namespace Console_Linq;

public class Task4
{
    // 29. Display employees by their first name in ascending order.
    public static List<string> EmployeesByFirstNameAscending()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.OrderBy(x => x.FirstName).Select(x => x.FirstName);
        return new List<string>(result);
    }

    // 30. Display employees by department name in descending order.
    public static List<string> EmployeesByDepartmentNameDescending()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.OrderByDescending(x => x.Department).Select(x => x.Department);
        return new List<string>(result);
    }

    // 31. Display employees by department name descending and first name in ascending order.
    public static List<string> EmployeesByDepartmentNameDescendingAndFirstNameAscending()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.OrderByDescending(x => x.Department).ThenBy(x => x.FirstName)
            .Select(x => x.Department + " " + x.FirstName);
        return new List<string>(result);
    }

    // 32. Display employees by their first name in ascending order and last name in descending order.
    public static List<string> EmployeesByFirstNameAscendingAndLastNameDescending()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName)
            .Select(x => x.FirstName + " " + x.LastName);
        return new List<string>(result);
    }

    // 33. Display employees by their Joining Date using Reverse() operator.
    public static List<Employee> EmployeesByJoiningDateUsingReverse()
    {
        using var context = new ApplicationDbContext();
        var result = context.Employee.OrderByDescending(e => e.JoiningDate).ToList();
        return result;
    }
}