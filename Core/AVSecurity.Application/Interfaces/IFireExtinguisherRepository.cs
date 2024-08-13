using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IFireExtinguisherRepository
    {
        Task<int> SaveFireExtinguisher(FireExtinguisher_Request parameters);

        Task<IEnumerable<FireExtinguisher_Response>> GetFireExtinguisherList(FireExtinguisherSearch_Request parameters);

        Task<FireExtinguisher_Response?> GetFireExtinguisherById(int Id);
    }
}
