using Nyobanyoba.Handler;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Nyobanyoba.Controller
{
    public class UserController
    {
        public static Response<List<MsUser>> GetAllUsers()
        {
            return UserHandler.GetAllUsers();
        }

        public static Response<List<MsUser>> GetAllCustomers()
        {
            return UserHandler.GetAllCustomers();
        }

        public static Response<MsUser> LoginUser(String  username, String password)
        {
            return UserHandler.LoginUser(username, password);
        }

        public static Response<MsUser> RegisterUser(String username, String email, String password, String confirm, String dob, String gender)
        {
            String error = String.Empty;

            if (username.Length < 5 || username.Length > 15) //tolong
            {
                error = "Username length must be between 5 and 15 alphabet with space only and cannot be empty.";
            }
            else if (!email.EndsWith(".com"))
            {
                error = "Email must end with ‘.com’ and cannot be empty.";
            }
            else if (gender.Equals(String.Empty)){
                error = "Gender must be chosen.";
            }
            else if (password.Equals(String.Empty))
            {
                error = "Password cannot be empty.";
            }
            else if (!password.All(char.IsLetterOrDigit))
            {
                error = "Password must be alphanumeric.";
            }
            else if (password != confirm)
            {
                error = "Confirmation password must be the same as password.";
            }
            else if (dob.Equals(String.Empty))
            {
                error = "Date of birth must be chosen.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            return UserHandler.RegisterUser(username, email, DateTime.Parse(dob), gender, password);
        }

        public static Response<MsUser> UpdateUserInfo(int uid, String username, String email, String dob, String gender)
        {
            String error = String.Empty;

            if (username.Length < 5 || username.Length > 15) //tolong
            {
                error = "Username length must be between 5 and 15 alphabet with space only and cannot be empty.";
            }
            else if (!email.EndsWith(".com"))
            {
                error = "Email must end with ‘.com’ and cannot be empty.";
            }
            else if (gender.Equals(String.Empty))
            {
                error = "Gender must be chosen.";
            }
            else if (dob.Equals(String.Empty))
            {
                error = "Date of birth must be chosen.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            var res = UserHandler.UpdateUserInfo(uid, username, email, DateTime.Parse(dob), gender);

            if (!res.Success)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = res.Message,
                    Payload = null
                };
            }
            return res;
        }

        public static Response<MsUser> UpdateUserPassword(int uid, String password, String newpassword)
        {
            String error = String.Empty;

            if (newpassword.Equals(String.Empty))
            {
                error = "Password cannot be empty.";
            }
            else if (!newpassword.All(char.IsLetterOrDigit))
            {
                error = "Password must be alphanumeric.";
            }

            if (!error.Equals(String.Empty))
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = error,
                    Payload = null
                };
            }

            var res = UserHandler.UpdateUserPassword(uid, password, newpassword);
            
            if(!res.Success)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = res.Message,
                    Payload = null
                };
            } 
            return res;
        }

        public static MsUser GetUserById(int uid)
        {
            return UserHandler.GetUserById(uid);
        }

        public static String GetRole(int uid)
        {
            return UserHandler.GetRole(uid);
        }
    }
}