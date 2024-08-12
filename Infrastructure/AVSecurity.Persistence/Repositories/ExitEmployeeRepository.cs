using AVSecurity.Application.Helpers;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Persistence.Repositories
{
    public class ExitEmployeeRepository : GenericRepository, IExitEmployeeRepository
    {
        private IConfiguration _configuration;

        public ExitEmployeeRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveExitEmployee(ExitEmployee_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@IsBadgeHandedOver", parameters.IsBadgeHandedOver);
            queryParameters.Add("@IsMaterialsCarried", parameters.IsMaterialsCarried);
            queryParameters.Add("@YesDesc", parameters.YesDesc);
            queryParameters.Add("@AnyObservations", parameters.AnyObservations);
            queryParameters.Add("@VehicleNo", parameters.VehicleNo);
            queryParameters.Add("@IsNotificationToAdmin", parameters.IsNotificationToAdmin);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveExitEmployee", queryParameters);
        }

        public async Task<IEnumerable<ExitEmployee_Response>> GetExitEmployeeList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<ExitEmployee_Response>("GetExitEmployeeList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<ExitEmployee_Response?> GetExitEmployeeById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<ExitEmployee_Response>("GetExitEmployeeById", queryParameters)).FirstOrDefault();
        }
    }
}
