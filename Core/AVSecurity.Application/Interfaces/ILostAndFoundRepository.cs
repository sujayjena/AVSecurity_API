using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface ILostAndFoundRepository
    {
        Task<int> SaveLostAndFound(LostAndFound_Request parameters);

        Task<IEnumerable<LostAndFound_Response>> GetLostAndFoundList(BaseSearchEntity parameters);

        Task<LostAndFound_Response?> GetLostAndFoundById(int Id);
    }
}
