using Advanced_Ecommerce.DataAccess.Concrete.EntityFramework.Mapping;
using Advanced_Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Concrete.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        //public ApplicationDbContext()
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL DATABASE Connection 
            // POSTGRESQL DATABASE 

           optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=E-Commerce;Trusted_Connection=true");

            //optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=Portfolio;User Id=postgres;Password=Sd635241;");
       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public DbSet<User> Users { get; set; }
    }
}
