using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SignalRApp.Models;

namespace SignalRApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                Session.Clear();
                FormsAuthentication.SignOut();
            }

            return View(new Account());
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (!string.IsNullOrEmpty(account.Username) && !string.IsNullOrEmpty(account.Password))
            {
                if (account.Username == "wfsiew")
                {
                    Session["userid"] = account.Username;
                    Session["adminid"] = "admin";
                }

                else
                    Session["userid"] = account.Username;

                FormsAuthentication.SetAuthCookie(account.Username, true);

                return RedirectToAction("Index", "Chat");
            }

            ViewBag.alert = "Incorrect username or password";

            return View(account);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
	}
}