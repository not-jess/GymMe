using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class TransactionHeaderRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<TransactionHeader> GetTransactionHeadersByUserId(int uid)
        {
            return db.TransactionHeaders.Where(x => x.UserID == uid).ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int tid)
        {
            TransactionHeader th = db.TransactionHeaders.Find(tid);
            return th;
        }

        public static bool CreateTransactionHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
            return true;
        }

        public static bool UpdateTransactionHeader(int uid, DateTime date, String status, int tid)
        {
            TransactionHeader th = db.TransactionHeaders.Find(tid);
            if (th == null)
            {
                return false;
            }

            th.Status = status;
            db.SaveChanges();
            return true;
        }
    }
}