using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models;

public class ComicBook
{
    [Key]
    public int ComicBookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal PricePerDay { get; set; }
}