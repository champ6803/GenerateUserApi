using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GenerateUserApi.Helper;
using GenerateUserApi.Models;
using Microsoft.AspNetCore.Cors;

namespace GenerateUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateUserController : ControllerBase
    {
        protected GenerateUserHelper genHelp = new GenerateUserHelper();
        // GET api/generateuser
        [HttpGet]
        public async Task<IEnumerable<Profile>> GetProfileAll()
        {
            var all = genHelp.GetAll();
            return await all;
        }

        // GET api/GenerateUser/admin@gmail.com
        [HttpGet("{email}")]
        public async Task<User> GenerateUser(string email)
        {
            var profile = await GenUserByProfile(email);
            var user = await GetUser(email);

            return user;
        }

        public async Task<Profile> GenUserByProfile(string email)
        {
            var profile = genHelp.GenerateUser(email);
            return await profile;
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
