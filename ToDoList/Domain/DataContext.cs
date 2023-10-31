using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entity;

namespace ToDoList.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
                
        }
    }
}
