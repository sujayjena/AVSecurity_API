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
    public class HandOverRepository : GenericRepository, IHandOverRepository
    {
        private IConfiguration _configuration;

        public HandOverRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveHandOver(HandOver_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@HandOverDate", parameters.HandOverDate);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@DutyBriefingAndRemarks", parameters.DutyBriefingAndRemarks);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@ToEmployeeId", parameters.ToEmployeeId);
            queryParameters.Add("@FromEmployeeId", parameters.FromEmployeeId);
            queryParameters.Add("@CourierName", parameters.CourierName);
            queryParameters.Add("@AirwayBillNumber", parameters.AirwayBillNumber);
            queryParameters.Add("@ReceivedById", parameters.ReceivedById);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveHandOver", queryParameters);
        }

        public async Task<IEnumerable<HandOver_Response>> GetHandOverList(HandOverSearch_Request parameters)
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

            var result = await ListByStoredProcedure<HandOver_Response>("GetHandOverList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<HandOver_Response?> GetHandOverById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<HandOver_Response>("GetHandOverById", queryParameters)).FirstOrDefault();
        }
    }
}
