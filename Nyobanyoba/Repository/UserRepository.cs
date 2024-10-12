using Nyobanyoba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyobanyoba.Repository
{
    public class UserRepository
    {
        private static Database1Entities db = DatabaseSingleton.GetInstance();

        public static MsUser GetUser(String username, String password)
        {
            MsUser user = db.MsUsers.Where(u => u.UserName == username && u.UserPassword == password).FirstOrDefault();
            return user;
        }

        public static List<MsUser> GetAllUsers()
        {
            return db.MsUsers.ToList();
        }

        public static MsUser GetUserByEmail(String email)
        {
            MsUser user = db.MsUsers.Where(u => u.UserEmail == email).FirstOrDefault();
            return user;
        }

        public static MsUser GetUserByName(String username)
        {
            MsUser user = db.MsUsers.Where(u => u.UserName == username).FirstOrDefault();
            return user;
        }

        public static MsUser GetUserById(int uid)
        {
            MsUser user = db.MsUsers.Find(uid);
            return user;
        }

        public static void CreateUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static bool UpdateUser(String username, String email, DateTime dob, String gender, String role, String password, int uid)
        {
            MsUser user = db.MsUsers.Find(uid);
            if (user == null)
            {
                return false;
            }

            user.UserName = username;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;
            db.SaveChanges();
            return true;
        }
    }
}