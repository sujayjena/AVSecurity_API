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
    public class EscortDailyFeedbackRepository : GenericRepository, IEscortDailyFeedbackRepository
    {
        private IConfiguration _configuration;

        public EscortDailyFeedbackRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveEscortDailyFeedback(EscortDailyFeedback_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@RouteId", parameters.RouteId);
            queryParameters.Add("@IsUsingMobileWhileDriving", parameters.IsUsingMobileWhileDriving);
            queryParameters.Add("@IsDrivingRash", parameters.IsDrivingRash);
            queryParameters.Add("@IsFollowedTrafficRules", parameters.IsFollowedTrafficRules);
            queryParameters.Add("@IsPoliteToEmployee", parameters.IsPoliteToEmployee);
            queryParameters.Add("@IsSecurityGuardAlert", parameters.IsSecurityGuardAlert);
            queryParameters.Add("@IsPepperOrChillySprayIssued", parameters.IsPepperOrChillySprayIssued);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveEscortDailyFeedback", queryParameters);
        }

        public async Task<IEnumerable<EscortDailyFeedback_Response>> GetEscortDailyFeedbackList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<EscortDailyFeedback_Response>("GetEscortDailyFeedbackList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<EscortDailyFeedback_Response?> GetEscortDailyFeedbackById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<EscortDailyFeedback_Response>("GetEscortDailyFeedbackById", queryParameters)).FirstOrDefault();
        }
    }
}
