using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Factory
{
    public class UserFactory
    {
        public static MsUser CreateUser(String username, String email, DateTime dob, String gender, String role, String password)
        {
            MsUser user = new MsUser()
            {
                UserName = username,
                UserEmail = email,
                UserDOB = dob,
                UserGender = gender,
                UserRole = role,
                UserPassword = password
            };
            return user;
        }
    }
}