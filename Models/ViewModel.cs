using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Entities;

namespace e_commerce.Models
{
    public class ViewModel
    {
        public List<User>? Users { get; set; } = new();

    }
}