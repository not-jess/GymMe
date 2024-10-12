using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Handler
{
    public class SupplementTypeHandler
    {
        public static Response<List<MsSupplementType>> GetAllSupplementTypes()
        {
            List<MsSupplementType> st = SupplementTypeRepository.GetAllSupplementTypes();

            if (st.Count == 0)
            {
                return new Response<List<MsSupplementType>>
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }

            return new Response<List<MsSupplementType>>
            {
                Success = true,
                Message = "Success",
                Payload = st
            };
        }
    }
}