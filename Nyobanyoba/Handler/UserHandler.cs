using Nyobanyoba.Factory;
using Nyobanyoba.Model;
using Nyobanyoba.Modules;
using Nyobanyoba.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Handler
{
    public class UserHandler
    {
        public static Response<List<MsUser>> GetAllUsers()
        {
            List<MsUser> users = UserRepository.GetAllUsers();
            if (users.Count == 0)
            {
                return new Response<List<MsUser>>()
                {
                    Success = false,
                    Message = "No Data",
                    Payload = null
                };
            }

            return new Response<List<MsUser>>()
            {
                Success = true,
                Message = "There is a Data",
                Payload = users
            };
        }

        public static Response<List<MsUser>> GetAllCustomers()
        {
            List<MsUser> users = UserRepository.GetAllUsers();
            List<MsUser> customers = users.Where(user => user.UserRole == "Customer").ToList();

            if (customers.Count == 0)
            {
                return new Response<List<MsUser>>()
                {
                    Success = false,
                    Message = "No Customers Found",
                    Payload = null
                };
            }

            return new Response<List<MsUser>>()
            {
                Success = true,
                Message = "Customers Found",
                Payload = customers
            };
        }

        public static Response<MsUser> RegisterUser(String username, String email, DateTime dob, String gender, String password)
        {
            MsUser check = UserRepository.GetUserByEmail(email);

            if (check != null)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Email is already in use",
                    Payload = null
                };
            }

            MsUser user = UserFactory.CreateUser(username, email, dob, gender, "Customer", password);

            UserRepository.CreateUser(user);

            return new Response<MsUser>()
            {
                Success = true,
                Message = "User has Succesfully registered",
                Payload = user
            };
        }

        public static Response<MsUser> LoginUser(String username, String password)
        {
            MsUser user = UserRepository.GetUserByName(username);

            if (user == null)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "User Not found",
                    Payload = null
                };
            }

            if (user.UserPassword != password)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Invalid password",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Success",
                Payload = user
            };
        }

        public static Response<MsUser> UpdateUserInfo(int uid, String username, String email, DateTime dob, String gender)
        {
            MsUser find = UserRepository.GetUserByEmail(email);
            
            if(find != null && find.UserID!=uid)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Email is already in use.",
                    Payload = null
                };
            }

            MsUser oldUser = UserRepository.GetUserById(uid);
            MsUser newUser = UserFactory.CreateUser(username, email, dob, gender, oldUser.UserRole, oldUser.UserPassword);
            newUser.UserID = oldUser.UserID;

            bool isUpdated = UserRepository.UpdateUser(username, email, dob, gender, newUser.UserRole, newUser.UserPassword, newUser.UserID);

            if (!isUpdated)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "User info fails to update.",
                    Payload= null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "User info successfully updated.",
                Payload = newUser
            };
        }

        public static Response<MsUser> UpdateUserPassword(int uid, String password, String newpassword)
        {
            MsUser oldUser = UserRepository.GetUserById(uid);

            if (oldUser.UserPassword != password)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Wrong Password",
                    Payload = null
                };
            }
;
            MsUser newUser = UserFactory.CreateUser(oldUser.UserName, oldUser.UserEmail, oldUser.UserDOB, oldUser.UserGender, oldUser.UserRole, newpassword);
            newUser.UserID = oldUser.UserID;

            bool isUpdated = UserRepository.UpdateUser(oldUser.UserName, oldUser.UserEmail, oldUser.UserDOB, oldUser.UserGender, oldUser.UserRole, newpassword, oldUser.UserID);

            if (!isUpdated)
            {
                return new Response<MsUser>()
                {
                    Success = false,
                    Message = "Password fails to update.",
                    Payload = null
                };
            }

            return new Response<MsUser>()
            {
                Success = true,
                Message = "Password successfuly updated.",
                Payload = newUser
            };
        }
        public static MsUser GetUserById(int uid)
        {
            MsUser user = UserRepository.GetUserById(uid);
            return user;
        }
        public static String GetRole(int uid)
        {
            MsUser user = UserRepository.GetUserById(uid);
            return user.UserRole;
        }
    }
}