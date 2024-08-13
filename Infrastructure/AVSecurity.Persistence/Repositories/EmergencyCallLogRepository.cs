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
    public class EmergencyCallLogRepository : GenericRepository, IEmergencyCallLogRepository
    {
        private IConfiguration _configuration;

        public EmergencyCallLogRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveEmergencyCallLog(EmergencyCallLog_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@ReportedBy", parameters.ReportedBy);
            queryParameters.Add("@CallDetails", parameters.CallDetails);
            queryParameters.Add("@ReceivedById", parameters.ReceivedById);
            queryParameters.Add("@EmergencyTypeId", parameters.EmergencyTypeId);
            queryParameters.Add("@EmergencyDesc", parameters.EmergencyDesc);
            queryParameters.Add("@EmergencyClosureId", parameters.EmergencyClosureId);
            queryParameters.Add("@ActionToken", parameters.ActionToken);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveEmergencyCallLog", queryParameters);
        }

        public async Task<IEnumerable<EmergencyCallLog_Response>> GetEmergencyCallLogList(EmergencyCallLogSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@FromDate", parameters.FromDate);
            queryParameters.Add("@ToDate", parameters.ToDate);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<EmergencyCallLog_Response>("GetEmergencyCallLogList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<EmergencyCallLog_Response?> GetEmergencyCallLogById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<EmergencyCallLog_Response>("GetEmergencyCallLogById", queryParameters)).FirstOrDefault();
        }
    }
}
