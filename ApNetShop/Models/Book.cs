using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApNetShop.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } //$$$
    }
}