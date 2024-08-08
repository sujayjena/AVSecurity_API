using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IHandOverRepository
    {
        Task<int> SaveHandOver(HandOver_Request parameters);

        Task<IEnumerable<HandOver_Response>> GetHandOverList(BaseSearchEntity parameters);

        Task<HandOver_Response?> GetHandOverById(int Id);
    }
}
