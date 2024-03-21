namespace Console_Linq;

public class Task3
{
    // 19. Find total salary and display it.
    public static void TotalSalary()
    {
        var context = new ApplicationDbContext();
        var q19 = context.Employee.Sum(x => x.Salary);
        Console.WriteLine("Total Salary: {0}", q19);
    }

    // 20. Find total number of employees of Admin department who belongs to Rajkot city.
    public static void TotalEmployeesOfAdminDepartmentBelongsToRajkot()
    {
        var context = new ApplicationDbContext();
        var q20 = context.Employee.Where(x => x.Department == "Admin" && x.City == "Rajkot").Count();
        Console.WriteLine("Total Employees of Admin department who belongs to Rajkot city: {0}", q20);
    }

    // 21. Find total salary of Distribution department.
    public static void TotalSalaryOfDistributionDepartment()
    {
        var context = new ApplicationDbContext();
        var q21 = context.Employee.Where(x => x.Department == "Distribution").Sum(x => x.Salary);
        Console.WriteLine("Total Salary of Distribution department: {0}", q21);
    }

    // 22. Find average salary of IT department.
    public static void AverageSalaryOfITDepartment()
    {
        var context = new ApplicationDbContext();
        var q22 = context.Employee.Where(x => x.Department == "IT").Average(x => x.Salary);
        Console.WriteLine("Average Salary of IT department: {0}", q22);
    }

    // 23. Find minimum salary of Customer Relationship department.
    public static void MinimumSalaryOfCustomerRelationshipDepartment()
    {
        var context = new ApplicationDbContext();
        var q23 = context.Employee.Where(x => x.Department == "Customer Relationship").Min(x => x.Salary);
        Console.WriteLine("Minimum Salary of Customer Relationship department: {0}", q23);
    }

    // 24. Find maximum salary of Distribution department who belongs to Baroda city.
    public static void MaximumSalaryOfDistributionDepartmentBelongsToBaroda()
    {
        var context = new ApplicationDbContext();
        var q24 = context.Employee.Where(x => x.Department == "Distribution" && x.City == "Baroda").Max(x => x.Salary);
        Console.WriteLine("Maximum Salary of Distribution department who belongs to Baroda city: {0}", q24);
    }

    // 25. Find number of employees whose Age is more than 40.
    public static void EmployeesAgeMoreThan40()
    {
        var context = new ApplicationDbContext();
        var q25 = context.Employee.Where(x => x.Age > 40).Count();
        Console.WriteLine("Number of employees whose Age is more than 40: {0}", q25);
    }

    // 26. Find total female employees working in Ahmedabad city.
    public static void TotalFemaleEmployeesWorkingInAhmedabad()
    {
        var context = new ApplicationDbContext();
        var q26 = context.Employee.Where(x => x.Gender == "Female" && x.City == "Ahmedabad").Count();
        Console.WriteLine("Number of employees whose is female and city is ahmedabad: {0}", q26);
    }

    // 27. Find total salary of male employees who belongs to Gandhinagar city and works in IT
    // department.
    public static void TotalSalaryOfMaleEmployeesInGandhinagarAndIT()
    {
        var context = new ApplicationDbContext();
        var totalSalary = context.Employee
            .Where(x => x.Gender == "Male" && x.City == "Gandhinagar" && x.Department == "IT")
            .Sum(x => x.Salary);
        Console.WriteLine("Total Salary of male employees who belongs to Gandhinagar city and works in IT: {0}",
            totalSalary);
    }

    // 28. Find average salary of male employees whose age is between 21 to 35.
    public static void AverageSalaryOfMaleEmployeesAgeBetween21To35()
    {
        var context = new ApplicationDbContext();
        var averageSalary = context.Employee
            .Where(x => x.Gender == "Male" && x.Age >= 21 && x.Age <= 35)
            .Average(x => x.Salary);
        Console.WriteLine("Average Salary of male employees whose age is between 21 to 35: {0}", averageSalary);
    }
}