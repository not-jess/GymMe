using Nyobanyoba.Factory;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Handler
{
    public class TransactionDetailHandler
    {
        public static Response<List<TransactionDetail>> GetAllTransactionDetails(int tid)
        {
            List<TransactionDetail> td = TransactionDetailRepository.GetAllTransactionDetails(tid);

            if (td.Count == 0)
            {
                return new Response<List<TransactionDetail>>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<List<TransactionDetail>>()
            {
                Success = true,
                Message = "Success",
                Payload = td
            };
        }

        public static Response<TransactionDetail> CreateTransactionDetail(int tid, int sid, int quantity)
        {
            TransactionDetail td = TransactionDetailFactory.CreateTransactionDetail(tid, sid, quantity);

            bool isCreated = TransactionDetailRepository.CreateTransactionDetail(td);

            if (!isCreated)
            {
                return new Response<TransactionDetail>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<TransactionDetail>()
            {
                Success = true,
                Message = "Success",
                Payload = td
            };
        }
    }
}