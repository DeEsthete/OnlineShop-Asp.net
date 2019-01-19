using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApNetShop.Models
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Book> Cart { get; set; }
    }
}