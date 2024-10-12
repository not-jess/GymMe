using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Factory
{
    public class CartFactory
    {
        public static MsCart CreateCart(int uid, int sid, int quantity)
        {
            MsCart cart = new MsCart()
            {
                UserID = uid,
                SupplementID = sid,
                Quantity = quantity
            };
            return cart;
        }
    }
}