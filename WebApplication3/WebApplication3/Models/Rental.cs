using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models;

public class Rental
{
    [Key]
    public int RentalID { get; set; }
    public int CustomerID { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; }
}