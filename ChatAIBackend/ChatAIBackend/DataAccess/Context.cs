using ChatAIBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAIBackend.DataAccess
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; } = null!;
    }
}
