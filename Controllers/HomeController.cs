using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.data;
using e_commerce.Entities;
using System.Data;

namespace e_commerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;

    }
    public IActionResult Index()
    {
        var viewModel = new ViewModel();
        viewModel.Products = _context.Products.Where(x => x.active == true).ToList();
        return View(viewModel);
    }
    [Route("kategoriler")]
    public IActionResult Privacy()
    {
        var viewModel = new ViewModel();
        viewModel.Users = _context.Users.Where(x => x.fullName == "efe").ToList();
        viewModel.Products = _context.Products.Where(y => y.active == true).ToList();
        return View(viewModel);
    }

    [HttpPost]
public IActionResult ToggleFavorite(int id)
{
    var product = _context.Products.FirstOrDefault(p => p.id == id);
    if (product == null)
        return NotFound();

    product.favorite = !product.favorite;
    _context.SaveChanges();

    return Json(new { success = true, favorite = product.favorite });
}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
