using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IOvernightParkingRepository
    {
        Task<int> SaveOvernightParking(OvernightParking_Request parameters);

        Task<IEnumerable<OvernightParking_Response>> GetOvernightParkingList(OvernightParkingSearch_Request parameters);

        Task<OvernightParking_Response?> GetOvernightParkingById(int Id);
    }
}
