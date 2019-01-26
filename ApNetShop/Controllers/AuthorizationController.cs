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

        [HttpPost]
        public ActionResult SignIn(List<string> property)
        {
            string login = property[0];
            string password = property[1];
            foreach(var i in db.Users)
            {
                if (i.Login == login)
                {
                    if (i.Password == password)
                    {
                        if (i.IsAdmin)
                        {
                            return RedirectToAction("Index", "Books", i);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Shop", i);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SignUp(List<string> property)
        {
            bool isOk = false;

            User user = new User();
            string fullName = property[0];
            string login = property[1];
            string password = property[2];
            string isAdmin = property[3];
            if (fullName != null && login != null && password != null && isAdmin != null)
            {
                user.FullName = fullName;
                user.Login = login;
                user.Password = password;
                if (isAdmin == "t")
                {
                    user.IsAdmin = true;
                    isOk = true;
                }
                else if (isAdmin == "f")
                {
                    user.IsAdmin = false;
                    isOk = true;
                }

                if (isOk)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Registration");
                }
            }
            return RedirectToAction("Registration");
        }
    }
}