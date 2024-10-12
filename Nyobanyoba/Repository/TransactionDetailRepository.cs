using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class TransactionDetailRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static List<TransactionDetail> GetAllTransactionDetails(int tid)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == tid).ToList();
        }

        public static bool CreateTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();
            return true;
        }
    }
}