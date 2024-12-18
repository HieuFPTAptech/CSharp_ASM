﻿namespace WebApplication3.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    
    public virtual User User { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}