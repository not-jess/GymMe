using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class SupplementTypeController
    {
        public static Response<List<MsSupplementType>> GetAllSupplementTypes()
        {
            return SupplementTypeHandler.GetAllSupplementTypes();
        }
    }
}