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
        public async Task<IEnumerable<Profile>> GetProfileList()
        {
            return await new ProfileLibrary().GetProfileList();
        }
        public async Task<User> GenerateUserByProfile(Profile profile)
        {
            return await new UserLibrary().GenerateUserByProfile(profile);
        }

        public async Task<User> GetUser(string email)
        {
            return await new UserLibrary().GetUser(email);
        }

        public async Task<Profile> GetProfileByEmail(string email)
        {
            return await new ProfileLibrary().GetProfileByEmail(email);
        }
    }
}