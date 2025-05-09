using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class Products
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int quantity { get; set; }
        public string? price { get; set; }
        public int userId { get; set; }
        public bool basket { get; set; }
        public bool showcase { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
    }
}