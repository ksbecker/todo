using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data.Models
{
    public partial class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public virtual DbSet<ToDo> ToDo { get; set; }
    }
}
