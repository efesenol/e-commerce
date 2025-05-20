using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class BasketItem
    {
        public int id { get; set; }
        public int basketId { get; set; }
        public int productId { get; set; }
    }
}