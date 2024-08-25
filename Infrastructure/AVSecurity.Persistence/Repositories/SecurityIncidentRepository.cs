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
    public class SecurityIncidentRepository : GenericRepository, ISecurityIncidentRepository
    {
        private IConfiguration _configuration;

        public SecurityIncidentRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveSecurityIncident(SecurityIncident_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@ReportedBy", parameters.ReportedBy);
            queryParameters.Add("@IncidentTypeId", parameters.IncidentTypeId);
            queryParameters.Add("@IncidentDesc", parameters.IncidentDesc);
            queryParameters.Add("@IncidentReportTo", parameters.IncidentReportTo);
            queryParameters.Add("@IncidentClosureBy", parameters.IncidentClosureBy);
            queryParameters.Add("@ActionTaken", parameters.ActionTaken);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSecurityIncident", queryParameters);
        }

        public async Task<IEnumerable<SecurityIncident_Response>> GetSecurityIncidentList(SecurityIncidentSearch_Request parameters)
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

            var result = await ListByStoredProcedure<SecurityIncident_Response>("GetSecurityIncidentList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<SecurityIncident_Response?> GetSecurityIncidentById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<SecurityIncident_Response>("GetSecurityIncidentById", queryParameters)).FirstOrDefault();
        }
    }
}
