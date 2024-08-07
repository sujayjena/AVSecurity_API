using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IEscortDailyFeedbackRepository
    {
        Task<int> SaveEscortDailyFeedback(EscortDailyFeedback_Request parameters);

        Task<IEnumerable<EscortDailyFeedback_Response>> GetEscortDailyFeedbackList(BaseSearchEntity parameters);

        Task<EscortDailyFeedback_Response?> GetEscortDailyFeedbackById(int Id);
    }
}
