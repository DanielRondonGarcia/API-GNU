

using Microsoft.EntityFrameworkCore;

namespace api.Modelos 
{
    public class ApiContext : DbContext 
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base (options) {
            //PoblarDatos();
            Database.EnsureCreated();
            Database.GenerateCreateScript();//Para crear un respaldo
            Database.Migrate();
         }

        public DbSet<Blog> Blogs { get; set; } // tabla

        //Forma Correcta
        protected virtual void OnModelCreating(ModelBuilder builder){
            builder.Entity<Blog>()
            .ToTable("Blogs")
            .HasKey(x=>x.Id);
            builder.Entity<Blog>().Property(Blog => Blog.Nombre).HasMaxLength(30);
            
            builder.Entity<Blog>().HasData(
                new Blog{
                    Id = 1,
                    Nombre = "Blog de Daniel",
                    Autor = "Daniel"},
                new Blog{
                    Id = 2,
                    Nombre = "Blog de kkviedes",
                    Autor = "Andriws"}
            );
        }

        //Forma Colombiana
        private void PoblarDatos(){
            this.Blogs.Add(
                new Blog{
                    Id = 1,
                    Nombre = "Blog de Daniel",
                    Autor = "Daniel"
                });

                this.Blogs.Add(
                new Blog{
                    Id = 2,
                    Nombre = "Blog de kkviedes",
                    Autor = "Andriws"
                });

                //Este es el commit
                this.SaveChanges();
        }



    }
}


