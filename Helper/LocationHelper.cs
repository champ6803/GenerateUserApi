using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInsertApi.Libraries;
using EmployeeInsertApi.Models;

namespace EmployeeInsertApi.Helper
{
    public class LocationHelper
    {
        public async Task<IEnumerable<Location>> GetAll()
        {
            return await new LocationLibrary().GetAll();
        }

      
    }
}