# EF Core Connectivity to DB

## Step 3: Package Installation

Ensure you have the following packages installed in your Console Application:

- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools**

## Step 4: Model & Context Setup

### Employee.cs & ApplicationDbContext.cs
Representing our database table, ensure your model matches the database table schema.

```csharp
   public class Employee 
   { 
        [Key] 
        public int AccountNo { get; set; } 
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? PhoneNo { get; set; } 
        public string? Email { get; set; } 
        public decimal? Salary { get; set; } 
        public DateTime? JoiningDate { get; set; } 
        public int? Age { get; set; } 
        public string? City { get; set; } 
        public string? Department { get; set; } 
        public string? Gender { get; set; } 
   } 
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=<servername>\<serverType>;Database=<DBNAME>;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }

```
