using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class SupplementController
    {
        public static Response<List<MsSupplement>> GetAllSupplements()
        {
            return SupplementHandler.GetAllSupplements();
        }

        public static Response<MsSupplement> GetSupplementById(int sid)
        {
            return SupplementHandler.GetSupplementById(sid);
        }

        public static Response<MsSupplement> CreateSupplement(String name, String expiry, String price, String stid)
        {
            String error = String.Empty;
            
            if (!name.Contains("Supplement"))
            {
                error= "Name must contain the word ‘Supplement’ and cannot be empty.";
            } else if(expiry.Equals(String.Empty))
            {
                error = "Date cannot be empty.";
            }
            else if (DateTime.Parse(expiry) <= DateTime.Now)
            {
                error = "Expiry date must be greater than today’s date and cannot be empty.";
            }
            else if (price.Equals(String.Empty))
            {
                error = "Price cannot be empty.";
            } else if (!price.All(char.IsDigit))
            {
                error = "Price must be a number.";
            }
            else if (Convert.ToInt32(price) < 3000)
            {
                error = "Price must be at least 3000";
            }
            else if (stid.Equals(String.Empty))
            {
                error = "Type ID cannot be empty.";
            }
            else if (!stid.All(char.IsDigit))
            {
                error = "Type ID must be a number.";
            }
            if (!error.Equals(String.Empty))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            return SupplementHandler.CreateSupplement(name, DateTime.Parse(expiry), Convert.ToInt32(price), Convert.ToInt32(stid));
        }

        public static Response<MsSupplement> UpdateSupplement(int sid, String name, String expiry, String price, String stid)
        {
            String error = String.Empty;

            if (!name.Contains("Supplement"))
            {
                error = "Name must contain the word ‘Supplement’ and cannot be empty.";
            }
            else if (expiry.Equals(String.Empty))
            {
                error = "Date cannot be empty.";
            }
            else if (DateTime.Parse(expiry) <= DateTime.Now)
            {
                error = "Expiry date must be greater than today’s date and cannot be empty.";
            }
            else if (price.Equals(String.Empty))
            {
                error = "Price cannot be empty.";
            }
            else if (!price.All(char.IsDigit))
            {
                error = "Price must be a number.";
            }
            else if (Convert.ToInt32(price) < 3000)
            {
                error = "Price must be at least 3000";
            }
            else if (stid.Equals(String.Empty))
            {
                error = "Type ID cannot be empty.";
            }
            else if (!stid.All(char.IsDigit))
            {
                error = "Type ID must be a number.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            return SupplementHandler.UpdateSupplement(sid, name, DateTime.Parse(expiry), Convert.ToInt32(price), Convert.ToInt32(stid));
        }

        public static Response<MsSupplement> DeleteSupplement(int sid)
        {
            return SupplementHandler.DeleteSupplement(sid);
        }
    }
}