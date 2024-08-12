using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IAttendanceRegisterRepository
    {
        Task<int> SaveAttendanceRegister(AttendanceRegister_Request parameters);

        Task<IEnumerable<AttendanceRegister_Response>> GetAttendanceRegisterList(AttendanceRegisterSearch_Request parameters);

        Task<AttendanceRegister_Response?> GetAttendanceRegisterById(int Id);
    }
}
