using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obras.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
    }
}