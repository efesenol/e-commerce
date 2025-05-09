using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class Menus
    {
        public int id { get; set; }
        public string? name { get; set; }
        public bool subMenu { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
        public DateTime createTime { get; set; }
    }
}