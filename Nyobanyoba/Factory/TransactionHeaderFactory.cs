using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int uid, DateTime date, String status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                UserID = uid,
                TransactionDate = date,
                Status = status
            };
            return transactionHeader;
        }
    }
}