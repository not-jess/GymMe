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
    public class SupplementHandler
    {
        public static Response<List<MsSupplement>> GetAllSupplements()
        {
            List<MsSupplement> supplement = SupplementRepository.GetAllSupplements();

            if (supplement.Count == 0)
            {
                return new Response<List<MsSupplement>>
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<List<MsSupplement>>
            {
                Success = true,
                Message = "Success",
                Payload = supplement
            };
        }

        public static Response<MsSupplement> GetSupplementById(int id)
        {
            MsSupplement supplement = SupplementRepository.GetSupplementById(id);

            if (supplement == null)
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<MsSupplement>
            {
                Success = true,
                Message = "Success",
                Payload = supplement
            };
        }

        public static Response<MsSupplement> CreateSupplement(String name, DateTime expiry, int price, int stid)
        {
            MsSupplement supplement = SupplementFactory.CreateSupplement(name, expiry, price, stid);

            bool isCreated = SupplementRepository.CreateSupplement(supplement);

            if (!isCreated)
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Fail to be create",
                    Payload = null
                };
            }

            return new Response<MsSupplement>
            {
                Success = true,
                Message = "Create success",
                Payload = supplement
            };
        }

        public static Response<MsSupplement> UpdateSupplement(int sid, String name, DateTime expiry, int price, int stid)
        {
            MsSupplement newsupplement = SupplementFactory.CreateSupplement(name, expiry, price, stid);
            newsupplement.SupplementID = sid;

            bool isUpdated = SupplementRepository.UpdateSupplement(newsupplement.SupplementName, newsupplement.SupplementExpiryDate, newsupplement.SupplementPrice, newsupplement.SupplementTypeID, newsupplement.SupplementID);

            if (!isUpdated)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Update fail",
                    Payload = null
                };
            }

            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Updated",
                Payload = newsupplement
            };
        }

        public static Response<MsSupplement> DeleteSupplement(int sid)
        {
            bool isDeleted = SupplementRepository.DeleteSupplement(sid);

            if (!isDeleted)
            {
                return new Response<MsSupplement>
                {
                    Success = false,
                    Message = "Delete fail",
                    Payload = null
                };
            }

            return new Response<MsSupplement>
            {
                Success = true,
                Message = "Deleted",
                Payload = null
            };
        }
    }
}