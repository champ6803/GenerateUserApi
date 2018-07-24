using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenerateUserApi.Models;

namespace GenerateUserApi.Libraries
{
    public class GenerateUserLibrary
    {
        ProfileDAL prodDal = new ProfileDAL();
        UserDAL userDal = new UserDAL();

        public async Task<IEnumerable<Profile>> GetAll()
        {
            var all = await prodDal.All();
            return all;
        }

        public async Task<User> GetUser(string email) {
            var user = await userDal.GetUser(email);
            return user;
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

        public async Task<Profile> GenerateUserPass(string email)
        {
            var getProf = await prodDal.GetProfile(email);

            Profile p = new Profile();
            User u = new User();

            string Username;
            string Password;
            if (getProf != null)
            {
                if (getProf.type_account == "Application")
                {
                    Username = email;
                    Password = GeneratePassword();

                    u.user = Username;
                    u.pwd = Password;
                }
                else if (getProf.type_account == "Exam")
                {
                    Username = GenerateUserFOrExam();
                    Password = GeneratePassword();

                    u.user = Username;
                    u.pwd = Password;
                }

                u.email = email;                
                u.type_account = getProf.type_account;
                var user = userDal.InsertUser(u);

                p.id = getProf.id;
                p.name = getProf.name;
                p.email = email;
                p.type_account = getProf.type_account;
            }
            return p;
        }


    }
}