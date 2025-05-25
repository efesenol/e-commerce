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
    [Route("farvoriler")]
    public IActionResult Favorite()
    {
        var userId = HttpContext.Session.GetInt32("Usersid");
        if (userId == null)
        {
            return Redirect("/Login");
        }
        var viewModel = new ViewModel();
        viewModel.Products = _context.Products.Where(x => x.active == true).ToList();
        return View(viewModel);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        var viewModel = new ViewModel
        {
            Products = _context.Products.Where(y => y.active == true).ToList(),
            Product = product
        };


        return View(viewModel);
    }
    [HttpPost]
    public IActionResult AddToBasket(int id)
    {
        var userId = HttpContext.Session.GetInt32("Usersid");
        if (userId == null)
        {
            TempData["ErrorMessage"] = "Sepete eklemek için giriş yapmalısınız.";
            return Redirect("/Login");
        }

        var basket = _context.Basket.FirstOrDefault(b => b.userId == userId);
        if (basket == null)
        {
            basket = new Basket { userId = userId.Value };
            _context.Basket.Add(basket);
            _context.SaveChanges();
        }

        bool alreadyExists = _context.BasketItem
            .Any(b => b.basketId == basket.id && b.productId == id);

        if (!alreadyExists)
        {
            _context.BasketItem.Add(new BasketItem
            {
                basketId = basket.id,
                productId = id
            });
            _context.SaveChanges();
        }

        return RedirectToAction("Index", "Home");
    }
    [Route("profilim")]
    public IActionResult Profile()
    {
        var userId = HttpContext.Session.GetInt32("Usersid");
        if (userId == null)
        {
            TempData["ErrorMessage"] = "Sepete eklemek için giriş yapmalısınız.";
            return Redirect("/Login");
        }

        var viewModel = new ViewModel();
        viewModel.Users = _context.Users.Where(x => x.active == true).ToList();
        return View(viewModel); 
    }

}
