using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tijarat.models
{
    public class CartProducts
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
    }
}