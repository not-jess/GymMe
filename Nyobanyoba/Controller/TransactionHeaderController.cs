using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class TransactionHeaderController
    {
        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            return TransactionHeaderHandler.GetAllTransactionHeaders();
        }

        public static Response<List<TransactionHeader>> GetTransactionHeadersByUserId(int uid)
        {
            return TransactionHeaderHandler.GetTransactionHeadersByUserId(uid);
        }

        public static Response<TransactionHeader> UpdateTransactionHeader(int tid, String status)
        {
            return TransactionHeaderHandler.UpdateTransactionHeader(tid, status);
        }
    }
}