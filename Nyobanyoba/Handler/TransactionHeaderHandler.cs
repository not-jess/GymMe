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
    public class TransactionHeaderHandler
    {
        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            List<TransactionHeader> th = TransactionHeaderRepository.GetAllTransactionHeaders();

            if (th.Count == 0)
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = false,
                    Message = "No Data",
                    Payload = null
                };
            }

            return new Response<List<TransactionHeader>>()
            {
                Success = true,
                Message = "There is a Data",
                Payload = th
            };
        }

        public static Response<List<TransactionHeader>> GetTransactionHeadersByUserId(int uid)
        {
            List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetTransactionHeadersByUserId(uid);

            if (transactionHeaders.Count == 0)
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = false,
                    Message = "Failed to get transaction headers",
                    Payload = null
                };
            }

            return new Response<List<TransactionHeader>>()
            {
                Success = true,
                Message = "Successfully get transaction headers",
                Payload = transactionHeaders
            };
        }

        public static Response<TransactionHeader> CreateTransactionHeader(int uid, DateTime date, String status)
        {
            TransactionHeader th = TransactionHeaderFactory.CreateTransactionHeader(uid, date, status);

            bool isCreated = TransactionHeaderRepository.CreateTransactionHeader(th);

            if (!isCreated)
            {
                return new Response<TransactionHeader>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "Success",
                Payload = th
            };
        }

        public static Response<TransactionHeader> UpdateTransactionHeader(int tid, String status)
        {
            TransactionHeader th = TransactionHeaderRepository.GetTransactionHeaderById(tid);
            TransactionHeader newth = TransactionHeaderFactory.CreateTransactionHeader(th.UserID, th.TransactionDate, status);
            newth.TransactionID = tid;

            bool isUpdated = TransactionHeaderRepository.UpdateTransactionHeader(newth.UserID, newth.TransactionDate, status, newth.TransactionID);

            if (!isUpdated)
            {
                return new Response<TransactionHeader>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "Success",
                Payload = th
            };
        }
    }
}