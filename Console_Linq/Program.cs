// See https://aka.ms/new-console-template for more information

using Console_Linq;

Console.WriteLine("Hello, World!");

var context = new ApplicationDbContext();
//For example, Display FirstName of all employees.
var q1 = context.Employee.Select(x => x.FirstName);
foreach (var employee in Task1.GetEmployeeDetails())
{
    Console.WriteLine("\n {0}", employee);
    // Console.WriteLine(employee.FirstName);
}