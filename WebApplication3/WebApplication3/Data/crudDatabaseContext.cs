using Microsoft.EntityFrameworkCore;
using Bogus;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class crudDatabaseContext : DbContext
{
    public crudDatabaseContext(DbContextOptions<crudDatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.ProductId }); 

        var userFaker = new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email());
        var users = userFaker.Generate(3);

        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Random.Decimal(5, 500));
        var products = productFaker.Generate(30);

        var orderId = 1;
        var orderFaker = new Faker<Order>()
            .RuleFor(o => o.Id, f => orderId++)
            .RuleFor(o => o.UserId, f => f.PickRandom(users).Id)
            .RuleFor(o => o.OrderDate, f => f.Date.Recent(30));
        var orders = orderFaker.Generate(10);

        var orderDetails = new List<OrderDetail>();
        foreach (var order in orders)
        {
            var usedProductIds = new HashSet<int>(); // Tập hợp để lưu các ProductId đã dùng cho Order này
            var detailsCount = new Random().Next(2, 5); // Số lượng OrderDetail cho Order này

            for (int i = 0; i < detailsCount; i++)
            {
                int productId;
                do
                {
                    productId = new Random().Next(1, products.Count + 1); // Lấy ngẫu nhiên ProductId
                } while (usedProductIds.Contains(productId)); // Kiểm tra nếu đã sử dụng ProductId này

                usedProductIds.Add(productId);

                orderDetails.Add(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Quantity = new Random().Next(1, 10),
                    UnitPrice = products.First(p => p.Id == productId).Price
                });
            }
        }

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderDetail>().HasData(orderDetails);
    }
}
