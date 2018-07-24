using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInsertApi.Models;

namespace EmployeeInsertApi.Libraries
{
    public class LocationLibrary
    {
        LocationDAL locdal = new LocationDAL();
        
        public async Task<IEnumerable<Location>> GetAll()
        {
            var all = await locdal.All();
            return all;
        }
    }
}