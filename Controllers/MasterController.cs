using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeInsertApi.Helper;
using EmployeeInsertApi.Models;
using Microsoft.AspNetCore.Cors;

namespace EmployeeInsertApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        protected LocationHelper locHelp = new LocationHelper();
        protected ComputerHelper comHelp = new ComputerHelper();

        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocationAll()
        {
            var all = locHelp.GetAll();
            return await all;
        }

       [HttpGet("getlocation")]
        public async Task<IEnumerable<Location>> GetLocationList()
        {
            var all = locHelp.GetAll();
            return await all;
        }

        [HttpGet("getcomputerlang")]
        public async Task<IEnumerable<Computer>> GetComputerLangList()
        {
            var all = comHelp.GetAll();
            return await all;
        }

        //   [HttpGet("getposition")]
        // public async Task<IEnumerable<Position>> getPositionList()
        // {
        //     var all = comHelp.GetAll();
        //     return await all;
        // }

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
