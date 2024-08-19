using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IOutgoingCourierRepository
    {
        Task<int> SaveOutgoingCourier(OutgoingCourier_Request parameters);

        Task<IEnumerable<OutgoingCourier_Response>> GetOutgoingCourierList(OutgoingCourierSearch_Request parameters);

        Task<OutgoingCourier_Response?> GetOutgoingCourierById(int Id);
    }
}
