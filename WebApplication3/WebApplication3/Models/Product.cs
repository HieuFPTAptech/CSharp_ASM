namespace WebApplication3.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}