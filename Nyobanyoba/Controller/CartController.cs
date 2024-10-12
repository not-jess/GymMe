using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class CartController
    {
        public static Response<List<MsCart>> GetCartsByUserId(int uid)
        {
            return CartHandler.GetCartsByUserId(uid);
        }

        public static Response<MsCart> CreateCart(int uid, int sid, String quantity)
        {
            String error = String.Empty;

            if (quantity.Equals(String.Empty))
            {
                error = "Quantity cannot be empty";
            } 
            else if (!quantity.All(char.IsDigit))
            {
                error = "Quantity must be a number.";
            }
            else if (Convert.ToInt32(quantity) <= 0)
            {
                error = "Quantity must be bigger than 0.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsCart>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            return CartHandler.CreateCart(uid, sid, Convert.ToInt32(quantity));
        }

        public static Response<MsCart> UpdateCart(int cid, int uid, int sid, String quantity)
        {
            String error = String.Empty;

            if (quantity == String.Empty)
            {
                error = "Quantity cannot be empty.";
            }
            else if (Convert.ToInt32(quantity) <= 0)
            {
                error = "Quantity must > 0 and cannot be empty.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsCart>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            return CartHandler.UpdateCart(cid, uid, sid, Convert.ToInt32(quantity));
        }
        public static Response<List<MsCart>> CheckoutCart(int uid)
        {
            return CartHandler.CheckoutCart(uid);
        }

        public static Response<List<MsCart>> DeleteCart(int uid)
        {
            return CartHandler.DeleteCart(uid);
        }


    }
}