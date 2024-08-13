using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IExitEmployeeRepository
    {
        Task<int> SaveExitEmployee(ExitEmployee_Request parameters);

        Task<IEnumerable<ExitEmployee_Response>> GetExitEmployeeList(ExitEmployeeSearch_Request parameters);

        Task<ExitEmployee_Response?> GetExitEmployeeById(int Id);
    }
}
