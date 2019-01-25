using ApNetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApNetShop.Controllers
{
    public class AuthorizationController : Controller
    {
        private ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn(User user)
        {
            foreach(var i in db.Users)
            {
                if (i.Login == user.Login)
                {
                    if (i.Password == user.Password)
                    {
                        ViewBag.User = i;
                        if (i.IsAdmin)
                        {
                            return View("/Books/Index");
                        }
                        else
                        {
                            return View("/Shop/Index");
                        }
                    }
                }
            }
            return View("Index");
        }
    }
}