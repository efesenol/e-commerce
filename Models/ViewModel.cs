using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Entities;

namespace e_commerce.Models
{
    public class ViewModel
    {
        public List<Users>? Users { get; set; }
        public List<Products>? Products { get; set; }
        public Products? Product { get; set; }
        public List<Menus>? Menus { get; set; } 
        public List<Basket>? Basket { get; set; } 
        public List<BasketItem>? BasketItem { get; set; } 
        

        

    }
}