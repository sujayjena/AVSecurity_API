using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IIncomingCourierRepository
    {
        Task<int> SaveIncomingCourier(IncomingCourier_Request parameters);

        Task<IEnumerable<IncomingCourier_Response>> GetIncomingCourierList(IncomingCourierSearch_Request parameters);

        Task<IncomingCourier_Response?> GetIncomingCourierById(int Id);
    }
}
