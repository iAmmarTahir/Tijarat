using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tijarat.models;

namespace Tijarat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                Session["ordersCount"] = AdminCRUD.getOrdersCount();
                Session["adsCount"] = AdminCRUD.getAdsCount();
                Session["productsCount"] = AdminCRUD.getProductsCount();
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginIt(string email, string password)
        {
            Session["admin"] = AdminCRUD.isAdminLoggedIn(email, password);
            return View();
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            Session["ordersCount"] = null;
            Session["adsCount"] = null;
            Session["productsCount"] = null;
            Response.Redirect("~/Admin/Login");
            return null;
        }

        public ActionResult Orders()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View(AdminCRUD.getOrderDetails());
            }
        }

        public ActionResult UpdateOrderStatus(int orderID)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                AdminCRUD.updateStatusOfOrder(orderID);
                Response.Redirect("~/Admin/Orders");
                return null;
            }
            
        }

        public ActionResult Ads()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View(AdminCRUD.getAdsDetails());
            }
        }

        public ActionResult DeleteAd(int adID)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                AdminCRUD.DeleteAds(adID);
                Response.Redirect("~/Admin/Ads");
                return null;
            }
           
        }

        public ActionResult NewAd()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View();
            }
        }

        public ActionResult SaveIt(int adID, int adminID, string product, string adContent, string imgUrl)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                int ret = AdminCRUD.CreateAd(adID, adminID, product, adContent, imgUrl);
                if(ret == 0)
                {
                    Response.Redirect("~/Admin/Ads");
                }
                else
                {
                    return View();
                }
               
                return null;
            }   
        }

        public ActionResult Products()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View(AdminCRUD.GetProductDetails());
            }
        }

        public ActionResult DeleteProduct(int productID)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                AdminCRUD.DeleteProducts(productID);
                Response.Redirect("~/Admin/Products");
                return null;
            }

        }

        public ActionResult NewProduct()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View();
            }
        }

        public ActionResult SaveProduct(int prodID, string name, string imgUrl, string desc, int price, string category, int qty)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                int ret = AdminCRUD.CreateProduct(prodID, name, imgUrl, desc, price, category, qty);
                if (ret == 0)
                {
                    Response.Redirect("~/Admin/Products");
                }
                else
                {
                    return View();
                }

                return null;
            }
        }

        public ActionResult Categories()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View(AdminCRUD.GetCategories());
            }
        }

        public ActionResult NewCategory()
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                return View();
            }
        }

        public ActionResult SaveCategory(int catID, string catName)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login");
                return null;
            }
            else
            {
                AdminCRUD.CreateCategory(catID, catName);
                
                Response.Redirect("~/Admin/Categories");
                
                return null;
            }
        }

    }
}