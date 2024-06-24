﻿using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IUserRepository  
    {
        #region User 

        Task<int> SaveUser(User_Request parameters);

        Task<IEnumerable<User_Response>> GetUserList(BaseSearchEntity parameters);

        Task<User_Response?> GetUserById(long Id);

        Task<IEnumerable<UserListByRole_Response>> GetUserLisByRoleIdOrRoleName(UserListByRole_Search parameters);

        Task<IEnumerable<SelectList_Response>> GetReportingToEmployeeForSelectList(ReportingToEmpListParameters parameters);

        Task<IEnumerable<EmployeesListByReportingTo_Response>> GetEmployeesListByReportingTo(int EmployeeId);

        #endregion
    }
}
