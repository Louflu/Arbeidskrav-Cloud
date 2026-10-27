using Microsoft.EntityFrameworkCore;
namespace Arbeidskrav_cloud.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }

        public string? DbPath { get; }

    }
}
