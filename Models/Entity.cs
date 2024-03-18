using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Oseas.Models
{
    public class Entity : IdentityDbContext<ApplicationUser>
    {
        public Entity() : base()
        {



        }
        public Entity(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Productss { get; set; }
        public DbSet<ShopingCard>ShopingCards { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6EP3OR2\\SQLEXPRESS;Initial Catalog=overseas;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}




   


