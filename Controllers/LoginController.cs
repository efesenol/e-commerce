using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.data;
using e_commerce.Entities;
using System.Data;

namespace e_commerce.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    public readonly MyContext _context;

    public LoginController(ILogger<LoginController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;

    }
    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        var viewModel = new ViewModel();
        viewModel.Products = _context.Products.Where(x => x.active == true).ToList();
        return View(viewModel);
    }

    [HttpPost]
    [Route("Loginnow")]
    public JsonResult Logina([FromForm] string email, [FromForm] string password)
    {
        var viewModel = new LoginViewModel();

        try
        {
            if (_context == null)
            {
                throw new Exception("Database context (_context) null geliyor!");
            }

            if (_context.Users == null)
            {
                throw new Exception("Users tablosu (_context.Users) null geliyor!");
            }

            var Users = _context.Users
                .Where(a => a.active == true && a.email == email && a.password == password)
                .FirstOrDefault();

            if (Users != null)
            {
                HttpContext.Session.SetInt32("Usersid", Users.id);
                viewModel.ResultID = 1;
                string fullName = Users.fullName!;
                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    fullName = char.ToUpper(fullName[0]) + fullName.Substring(1).ToLower();
                }
                viewModel.ResultMessage = $"Hoş geldiniz {fullName}";

                viewModel.RedirectURL = "/";

                return Json(viewModel);
            }

            viewModel.ResultID = -1;
            viewModel.ResultMessage = "E-mail veya şifre hatalı!";
            viewModel.RedirectURL = "#";
        }
        catch (Exception ex)
        {
            viewModel.ResultID = -2;
            viewModel.ResultMessage = "Bir hata oluştu: " + ex.Message;
            viewModel.RedirectURL = "#";
        }

        return Json(viewModel);
    }

}
