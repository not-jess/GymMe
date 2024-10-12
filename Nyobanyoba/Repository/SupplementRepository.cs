using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class SupplementRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static List<MsSupplement> GetAllSupplements()
        {
            return db.MsSupplements.ToList();
        }

        public static MsSupplement GetSupplementById(int sid)
        {
            MsSupplement supplement = db.MsSupplements.Find(sid);
            return supplement;
        }

        public static bool CreateSupplement(MsSupplement supplement)
        {
            db.MsSupplements.Add(supplement);
            db.SaveChanges();
            return true;
        }

        public static bool UpdateSupplement(String name, DateTime expiry, int price, int stid, int sid)
        {
            MsSupplement supplement = db.MsSupplements.Find(sid);
            if (supplement == null)
            {
                return false;
            }

            supplement.SupplementName = name;
            supplement.SupplementPrice = price;
            supplement.SupplementExpiryDate = expiry;
            supplement.SupplementTypeID = stid;

            db.SaveChanges();
            return true;
        }

        public static bool DeleteSupplement(int sid)
        {
            MsSupplement delete = db.MsSupplements.Find(sid);
            if (delete == null)
            {
                return false;
            }

            db.MsSupplements.Remove(delete);
            db.SaveChanges();
            return true;
        }
    }
}