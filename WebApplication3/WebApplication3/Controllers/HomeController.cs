using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class HomeController : Controller
{
    private crudDatabaseContext _context;

    public HomeController(crudDatabaseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Truy vấn danh sách đơn hàng
        var orders = _context.Orders.ToList(); 

        return View(orders);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}