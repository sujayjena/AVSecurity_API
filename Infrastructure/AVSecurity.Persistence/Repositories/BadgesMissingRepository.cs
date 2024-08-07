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
    public class BadgesMissingRepository : GenericRepository, IBadgesMissingRepository
    {
        private IConfiguration _configuration;

        public BadgesMissingRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveBadgesMissing(BadgesMissing_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@BadgesMissingDate", parameters.BadgesMissingDate);
            queryParameters.Add("@EmployeeType", parameters.EmployeeType);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@VisitorTypeId", parameters.VisitorTypeId);
            queryParameters.Add("@ReasonTypeId", parameters.ReasonTypeId);
            queryParameters.Add("@BadgeDesc", parameters.BadgeDesc);
            queryParameters.Add("@BadgeNo", parameters.BadgeNo);
            queryParameters.Add("@BadgeLostDate", parameters.BadgeLostDate);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveBadgesMissing", queryParameters);
        }

        public async Task<IEnumerable<BadgesMissing_Response>> GetBadgesMissingList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<BadgesMissing_Response>("GetBadgesMissingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<BadgesMissing_Response?> GetBadgesMissingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<BadgesMissing_Response>("GetBadgesMissingById", queryParameters)).FirstOrDefault();
        }
    }
}
