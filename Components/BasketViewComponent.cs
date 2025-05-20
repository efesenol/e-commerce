using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.data;
using e_commerce.Entities;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Components
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly MyContext _context;

        public BasketViewComponent(MyContext _context)
        {
            this._context = _context;
        }

        public IViewComponentResult Invoke(int id)
        {
            var viewModel = new ViewModel();
    var userId = HttpContext.Session.GetInt32("Usersid");

    if (userId != null)
    {
        var userBasket = _context.Basket.FirstOrDefault(x => x.userId == userId);
        
        // Sepeti yoksa oluştur
        if (userBasket == null)
        {
            userBasket = new Basket { userId = userId.Value };
            _context.Basket.Add(userBasket);
            _context.SaveChanges();
        }

        // Sepet ürünlerini al
        var productIds = _context.BasketItem
            .Where(x => x.basketId == userBasket.id)
            .Select(x => x.productId)
            .ToList();

        // Ürünleri çek
        viewModel.Products = _context.Products
            .Where(p => productIds.Contains(p.id) && p.active)
            .ToList();
    }
    else
    {
        viewModel.Products = new List<Products>(); // Kullanıcı girmemişse boş sepet
    }

    return View(viewModel);
        }
    }
    
}