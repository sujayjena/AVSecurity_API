using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IBadgesMissingRepository
    {
        Task<int> SaveBadgesMissing(BadgesMissing_Request parameters);

        Task<IEnumerable<BadgesMissing_Response>> GetBadgesMissingList(BaseSearchEntity parameters);

        Task<BadgesMissing_Response?> GetBadgesMissingById(int Id);
    }
}
