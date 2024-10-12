using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class TransactionDetailController
    {
            public static Response<List<TransactionDetail>> GetAllTransactionDetails(int tid)
            {
                return TransactionDetailHandler.GetAllTransactionDetails(tid);
            }
    }
}