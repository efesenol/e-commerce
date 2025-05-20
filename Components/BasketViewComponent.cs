using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.data;
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
            ViewModel model = new ViewModel();
            model.Basket = _context.Basket.Where(m => m.id == 1).ToList();
            model.Products = _context.Products.Where(m => m.basket == true).ToList();
            model.BasketItem = _context.BasketItem.Where(m => m.id == 1).ToList();
            return View(model);
        }
    }
    
}