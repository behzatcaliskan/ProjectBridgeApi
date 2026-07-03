using Microsoft.EntityFrameworkCore;
using projectbridgeapi.Models;

namespace projebridgeapi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Developers> Developers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Kolye",
                    Description = "Gold, silver ve taşlı kolye modelleri"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Yüzük",
                    Description = "Minimal, taşlı ve günlük yüzük modelleri"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Bileklik",
                    Description = "Çelik, rose ve zincir bileklik modelleri"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Küpe",
                    Description = "İnci, halka ve minimal küpe modelleri"
                }
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    SupplierId = 4,
                    SupplierName = "Parıltı Takı Tedarik",
                    Phone = "0532 111 22 33",
                    City = "İstanbul"
                },
                new Supplier
                {
                    SupplierId = 2,
                    SupplierName = "GoldLine Aksesuar",
                    Phone = "0533 222 44 55",
                    City = "İzmir"
                },
                new Supplier
                {
                    SupplierId = 3,
                    SupplierName = "Rose Bijuteri",
                    Phone = "0534 333 55 66",
                    City = "Ankara"
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 4,
                    FullName = "Ayşe Yılmaz",
                    Phone = "0555 111 22 33",
                    Email = "ayse@mail.com"
                },
                new Customer
                {
                    CustomerId = 2,
                    FullName = "Elif Demir",
                    Phone = "0555 222 33 44",
                    Email = "elif@mail.com"
                },
                new Customer
                {
                    CustomerId = 3,
                    FullName = "Merve Kaya",
                    Phone = "0555 333 44 55",
                    Email = "merve@mail.com"
                }
            );
        }
    }
}