using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class ProductSize
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string? size { get; set; }
        public int quantity { get; set; }
        public int queue { get; set; }

    }
}