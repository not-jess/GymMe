using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Factory
{
    public class SupplementFactory
    {
        public static MsSupplement CreateSupplement(String name, DateTime expiry, int price, int stid)
        {
            MsSupplement supplement = new MsSupplement()
            {
                SupplementName = name,
                SupplementExpiryDate = expiry,
                SupplementPrice = price,
                SupplementTypeID = stid
            };
            return supplement;
        }
    }
}