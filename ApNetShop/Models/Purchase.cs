using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApNetShop.Models
{
    public class Purchase : Entity
    {
        public User Customer { get; set; }
        public virtual ICollection<Book> Products { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}