using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInsertApi.Models;

namespace EmployeeInsertApi.Libraries
{
    public class ComputerLibrary
    {
        ComputerDAL comdal = new ComputerDAL();
        
        public async Task<IEnumerable<Computer>> GetAll()
        {
            var all = await comdal.All();
            return all;
        }
    }
}