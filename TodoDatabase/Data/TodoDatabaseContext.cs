using Microsoft.EntityFrameworkCore;
using TodoDatabase.Models;

namespace TodoDatabase.Data
{
    public class TodoDatabaseContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4I1E34D\\MSSQLSERVER01;Database=TodoDatabase;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
