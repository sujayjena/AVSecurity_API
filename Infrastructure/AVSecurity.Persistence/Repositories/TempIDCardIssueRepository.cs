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
    public class TempIDCardIssueRepository : GenericRepository, ITempIDCardIssueRepository
    {
        private IConfiguration _configuration;

        public TempIDCardIssueRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveTempIDCardIssue(TempIDCardIssue_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@IDCardNo", parameters.IDCardNo);
            queryParameters.Add("@ReasonForIssuance", parameters.ReasonForIssuance);
            queryParameters.Add("@Descriptions", parameters.Descriptions);
            queryParameters.Add("@ReturnDate", parameters.ReturnDate);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveTempIDCardIssue", queryParameters);
        }

        public async Task<IEnumerable<TempIDCardIssue_Response>> GetTempIDCardIssueList(TempIDCardIssueSearch_Request parameters)
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

            var result = await ListByStoredProcedure<TempIDCardIssue_Response>("GetTempIDCardIssueList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<TempIDCardIssue_Response?> GetTempIDCardIssueById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<TempIDCardIssue_Response>("GetTempIDCardIssueById", queryParameters)).FirstOrDefault();
        }
    }
}
