using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class SupplementTypeRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static List<MsSupplementType> GetAllSupplementTypes()
        {
            return db.MsSupplementTypes.ToList();
        }
    }
}