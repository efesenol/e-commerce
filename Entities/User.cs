using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class User
    {
        public int id { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}