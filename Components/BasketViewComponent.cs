using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using e_commerce.data;
using e_commerce.Entities;
using e_commerce.Models;
using Microsoft.AspNetCore.Http;

namespace e_commerce.Components
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly MyContext _context;

        public BasketViewComponent(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new ViewModel();
            var userId = HttpContext.Session.GetInt32("Usersid");

            if (userId != null)
            {
                var userBasket = _context.Basket.FirstOrDefault(x => x.userId == userId);

                if (userBasket == null)
                {
                    userBasket = new Basket { userId = userId.Value };
                    _context.Basket.Add(userBasket);
                    _context.SaveChanges();
                }

                // Sepetteki ürünleri ve bilgilerini getir
                var basketItems = _context.BasketItem
                .Where(x => x.basketId == userBasket.id)
                .ToList();
                var productIds = basketItems.Select(x => x.productId).ToList();

                var products = _context.Products
                    .Where(p => productIds.Contains(p.id) && p.active)
                    .ToList();

                viewModel.Products = products;
                viewModel.BasketItem = basketItems;
            }
            else
            {
                viewModel.Products = new List<Products>();
                viewModel.BasketItem = new List<BasketItem>();
            }

            return View(viewModel);
        }
    }
}
