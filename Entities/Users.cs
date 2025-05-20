using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Entities
{
    public class Users
    {
        public int id { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
        public DateTime? createTime { get; set; }
    }
}