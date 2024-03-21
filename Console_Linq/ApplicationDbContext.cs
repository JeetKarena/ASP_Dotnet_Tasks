using Microsoft.EntityFrameworkCore;

namespace Console_Linq
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee>? Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=JEET-KARENA\SQLEXPRESS;Database=Linq_Demo_DB;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}