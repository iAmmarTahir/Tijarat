using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tijarat.models;


namespace Tijarat.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {  
            return View(AdminCRUD.getAdsDetails());
        }

        public ActionResult Search(string product)
        {
            return View(CRUD.Search(product));
        }

        public ActionResult Categories()
        {
            return View(AdminCRUD.GetCategories());
        }

        public ActionResult Display(string Category)
        {
            return View(CRUD.SearchByCategory(Category));
        }

        public ActionResult Ads()
        {
            return View();
        }
    }
}