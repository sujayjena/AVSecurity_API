using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IPatrollingRepository
    {
        Task<int> SavePatrolling(Patrolling_Request parameters);

        Task<IEnumerable<Patrolling_Response>> GetPatrollingList(PatrollingSearch_Request parameters);

        Task<Patrolling_Response?> GetPatrollingById(int Id);
    }
}
