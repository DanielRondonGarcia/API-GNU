

using Microsoft.EntityFrameworkCore;

namespace api.Modelos 
{
    public class ApiContext : DbContext 
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base (options) { }

        public DbSet<Blog> Blogs { get; set; } // tabla
    }
}


