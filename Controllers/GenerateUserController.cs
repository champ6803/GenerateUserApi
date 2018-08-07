using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GenerateUserApi.Helper;
using GenerateUserApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace GenerateUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateUserController : ControllerBase
    {
        protected GenerateUserHelper genHelp = new GenerateUserHelper();
        // GET api/generateuser
        [HttpGet, Authorize]
        public async Task<IEnumerable<Profile>> GetProfileAll()
        {
            var all = genHelp.GetProfileList();
            return await all;
        }

         [HttpPost("getprofile"), Authorize]
        public async Task<Profile> GetProfileByEmail(string email)
        {
            //string email = "chingchana@gmail.com";
            var profile = genHelp.GetProfileByEmail(email);
            return await profile;
        }

        // GET api/GenerateUser/admin@gmail.com
        [HttpGet("{email}")]
        public async Task<User> GenerateUser(string email)
        {
            Profile profile = await genHelp.GetProfileByEmail(email);
            if (profile != null)
            {
                User user = await genHelp.GenerateUserByProfile(profile);
                return user;
            }
            return null;
        }

        public async Task<User> GetUser(string email)
        {
            var user = genHelp.GetUser(email);
            return await user;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}