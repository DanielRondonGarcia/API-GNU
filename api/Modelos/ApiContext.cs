

using Microsoft.EntityFrameworkCore;

namespace api.Modelos 
{
    public class ApiContext : DbContext 
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base (options) {
            //LlenarDatos();
            Database.EnsureCreated();
         }

        public DbSet<Blog> Blogs { get; set; } // tabla
        protected override void OnModelCreating(ModelBuilder builder){
            
            builder.Entity<Blog>().ToTable("Blogs");
            builder.Entity<Blog>().HasKey(Blog => Blog.Id);
            //builder.Entity<Blog>().Property(Blog => Blog.Id).ValueGeneratedOnAdd(); //Autoincrementar
            builder.Entity<Blog>().Property(Blog => Blog.Nombre).HasMaxLength(30);
            

            builder.Entity<Blog>().HasData(
                new Blog{
                Id = 1,
                Nombre = "Blog de Daniel",
                Autor = "Daniel"
                },
                new Blog{
                Id = 2,
                Nombre = "Blog de Fabia",
                Autor = "Fabia"
                }
            );
        }
        public void LlenarDatos(){
            this.Blogs.Add(
                new Blog{
                Id = 1,
                Nombre = "Blog de Daniel",
                Autor = "Daniel"
            });
            this.Blogs.Add(
                new Blog{
                Id = 2,
                Nombre = "Blog de Fabia",
                Autor = "Fabia"
            });
            this.SaveChanges();
        }
    }
}


