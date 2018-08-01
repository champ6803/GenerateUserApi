using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenerateUserApi.Models;
using GenerateUserApi.DAL;

namespace GenerateUserApi.Libraries
{
    public class UserLibrary
    {
        UserDAL userDal = new UserDAL();

        public async Task<User> GetUser(string email)
        {
            try
            {
                var user = await userDal.GetUserByEmail(email);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /*Generate for login application */
        private static Random random = new Random();

        public string GenerateUserFOrExam()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(s =>
             s[random.Next(s.Length)]).ToArray());
        }

        public string GeneratePassword()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 16).Select(s =>
             s[random.Next(s.Length)]).ToArray());
        }

        public async Task<User> GenerateUserByProfile(Profile profile)
        {
            try
            {
                if (profile != null)
                {
                    User u = new User();
                    if (profile.type_account == "Application")
                    {
                        u.user = profile.email;
                        u.pwd = GeneratePassword();
                    }
                    else if (profile.type_account == "Exam")
                    {
                        u.user = GenerateUserFOrExam();
                        u.pwd = GeneratePassword();
                    }

                    u.email = profile.email;
                    u.type_account = profile.type_account;
                    string user_id = await userDal.InsertUser(u);
                    if (!String.IsNullOrEmpty(user_id))
                    {
                        var user = await userDal.GetUserById(user_id);
                        return user;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
