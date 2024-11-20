using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shopier_dotnet.Models;
using ShopierService;

namespace shopier_dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IShopier _shopier;
    public HomeController(ILogger<HomeController> logger, IShopier shopier)
    {
        _logger = logger;
        _shopier = shopier;
    }

    public IActionResult Index()
    {
        return View();
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