using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Tijarat.models;
using System;


namespace Tijarat.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Products()
        {
            return View(AdminCRUD.GetProductDetails());
        }

        public ActionResult ShoppingCart(int id = 0, int qty = 0)
        {
            if (id != 0 && qty != 0)
            {
                SqlDataReader r = Cart.orderProduct(id, qty);
                CartProducts c = new CartProducts();
                if (r.Read())
                {
                    c.id = Int32.Parse(r[0].ToString());
                    c.name = r[1].ToString();
                    c.price = Int32.Parse(r[3].ToString());
                    c.imgUrl = r[2].ToString();
                    c.qty = qty;
                }
                if (Session["Cart"] == null)
                {
                    List<CartProducts> aList = new List<CartProducts>();
                    aList.Add(c);
                    Session["Cart"] = aList;
                }
                else
                {
                    List<CartProducts> aList = (List<CartProducts>)Session["Cart"];
                    aList.Add(c);
                    Session["Cart"] = aList;
                }
            }
            return View();
        }

        public ActionResult RemoveItem(int id, int qty)
        {
            List<CartProducts> aList = (List<CartProducts>)Session["Cart"];

            foreach(CartProducts item in aList)
            {
                if(item.id == id && item.qty == qty)
                {
                    aList.Remove(item);
                    break;
                }
            }
            Session["Cart"] = aList;
            return View();
        }

        public ActionResult CheckOut()
        {
            if(Session["access"] == null)
            {
                Response.Redirect("~/Registration/Register");
                return null;
            }
            else
            {
                int uID = (int)Session["access"];
                Random rnd = new Random();
                int ordNo = rnd.Next(10000);
                Cart.generateOrder(ordNo, uID, "Pending");
                List<CartProducts> aList = (List<CartProducts>)Session["Cart"];
                foreach(CartProducts a in aList)
                {
                    int itemNo = rnd.Next(10000);
                    Cart.generateItemOrder(itemNo, ordNo, a.id, a.qty);
                }
                Session["Cart"] = null;
                return View();
            }
        }
    }
}