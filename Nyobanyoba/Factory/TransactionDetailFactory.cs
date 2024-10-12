using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int tid, int sid, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = tid,
                SupplementID = sid,
                Quantity = quantity,
            };
            return transactionDetail;
        }
    }
}