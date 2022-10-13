using Microsoft.EntityFrameworkCore;
using TrelloTestApi.Modal;

namespace TrelloTestApi.Data
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext(DbContextOptions<TaskDataContext> options) : base(options)

        {

        }
        public DbSet<TaskModal> taskdb { get; set; }
        

    }
}
