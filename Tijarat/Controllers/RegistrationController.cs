using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Tijarat.models;
using System.Data.SqlClient;

namespace Tijarat.Controllers
{
    public class RegistrationController : Controller
    {
        
       
        // GET: Registration
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login(String email, String password)
        {
            Session["access"] = CRUD.isLoggedIn(email, password);
            SqlDataReader r = CRUD.getUserName((int)Session["access"]);
            if(r.Read())
            {
                Session["username"] = r[0].ToString();
            }
            return View();
        }

        public ActionResult SignUp(String Username, String Address, String Phone, String Date, String Email, String Pwd)
        {
            Session["access"] = CRUD.isRegistered(Username, Address, Phone, Date, Email, Pwd);
            SqlDataReader r = CRUD.getUserName((int)Session["access"]);
            if (r.Read())
            {
                Session["username"] = r[0].ToString();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["access"] = null;
            Session["username"] = null;
            Session["Cart"] = null;
            Response.Redirect("~/Home/Index");
            return null;
        }
        
    }
}