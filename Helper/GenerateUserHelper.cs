using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenerateUserApi.Libraries;
using GenerateUserApi.Models;

namespace GenerateUserApi.Helper
{
    public class GenerateUserHelper
    {
        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await new GenerateUserLibrary().GetAll();
        }

        public async Task<Profile> GenerateUser(string email)
        {
            return await new GenerateUserLibrary().GenerateUserPass(email);
        }

        public async Task<User> GetUser(string email) {
            return await new GenerateUserLibrary().GetUser(email);
        }
    }
}