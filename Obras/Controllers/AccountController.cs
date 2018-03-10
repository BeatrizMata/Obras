using Obras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Obras.Controllers
{
    public class AccountController : Controller
    {
        private AppplicationDBContext db = new AppplicationDBContext();
        [HttpGet]
        // GET: Account
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(ViewLogin user)
        {
            if (ModelState.IsValid)
            {
                if (Isvalid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                   
                    return RedirectToAction("Index", "Obras");
                }
                else
                {
                    ModelState.AddModelError("", "Datos incorrectos");
                }
            }
            return View(user);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Account");
        }

        private Usuarios getUser(string userName, string password)
        {
            Usuarios x = db.dbUsuarios.Where(m => m.UserName == userName && m.Password == password).FirstOrDefault();
            return x;
        }

        private bool Isvalid(string userName, string password)
        {
            Usuarios x = db.dbUsuarios.Where(m => m.UserName == userName && m.Password == password).FirstOrDefault();
            if (x == null)
                return false;
            else
                return true;
        }
    }
}