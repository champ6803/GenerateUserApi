using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInsertApi.Libraries;
using EmployeeInsertApi.Models;

namespace EmployeeInsertApi.Helper
{
    public class ComputerHelper
    {
        public async Task<IEnumerable<Computer>> GetAll()
        {
            return await new ComputerLibrary().GetAll();
        }

      
    }
}