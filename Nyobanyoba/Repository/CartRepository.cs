using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class CartRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static List<MsCart> GetCartsByUserId(int id)
        {
            return db.MsCarts.Where(x => x.UserID == id).ToList();
        }

        public static MsCart GetCartByUserIdAndSupplementId(int uid, int sid)
        {
            return db.MsCarts.Where(x => x.UserID == uid && x.SupplementID == sid).FirstOrDefault();
        }

        public static bool CreateCart(MsCart cart)
        {
            db.MsCarts.Add(cart);
            db.SaveChanges();
            return true;
        }

        public static bool UpdateCart(int uid, int sid, int quantity, int cid)
        {
            MsCart cart = db.MsCarts.Find(cid);
            if (cart == null)
            {
                return false;
            }

            cart.Quantity = quantity;

            db.SaveChanges();
            return true;
        }

        public static bool DeleteCart(int cid)
        {
            MsCart delete = db.MsCarts.Find(cid);
            if (delete == null)
            {
                return false;
            }

            db.MsCarts.Remove(delete);
            db.SaveChanges();
            return true;
        }
    }
}