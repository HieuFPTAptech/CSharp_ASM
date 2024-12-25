using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class crudDatabaseContext : DbContext
{
    public crudDatabaseContext(DbContextOptions<crudDatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<ComicBook> ComicBooks { get; set; }
    public DbSet<RentalDetail> RentalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RentalDetail>()
            .HasKey(rd => rd.RetalDetailID);

        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerID = 1, FullName = "Nguyen Hung", PhoneNumber = "0123456789", CreateAt = DateTime.Now }
        );

        modelBuilder.Entity<ComicBook>().HasData(
            new ComicBook { ComicBookID = 1, Title = "Conan", Author = "Aoyama", PricePerDay = 2.5M },
            new ComicBook { ComicBookID = 2, Title = "Doraemon", Author = "Fujiko", PricePerDay = 1.5M }
        );

        modelBuilder.Entity<Rental>().HasData(
            new Rental { RentalID = 1, CustomerID = 1, RentalDate = new DateTime(2024, 10, 1), ReturnDate = new DateTime(2024, 10, 10), Status = "Completed" }
        );

        modelBuilder.Entity<RentalDetail>().HasData(
            new RentalDetail { RetalDetailID = 1, RentalID = 1, ComicBookID = 1, Quantity = 1, PricePerDay = 2.5M },
            new RentalDetail { RetalDetailID = 2, RentalID = 1, ComicBookID = 2, Quantity = 3, PricePerDay = 1.5M }
        );
    }
}