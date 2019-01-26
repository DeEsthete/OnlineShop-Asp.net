using ApNetShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApNetShop.Controllers
{
    public class ShopController : Controller
    {
        private ShopContext db = new ShopContext();
        private User user;

        // GET: Shop
        public async Task<ActionResult> Index(User user)
        {
            this.user = user;
            ViewBag.User = user;
            return View(await db.Books.ToListAsync());
        }

        public ActionResult Cart()
        {
            return View();
        }

        public async Task<ActionResult> AddInCart(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            user.Cart.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index", "Shop", user);
        }
    }
}