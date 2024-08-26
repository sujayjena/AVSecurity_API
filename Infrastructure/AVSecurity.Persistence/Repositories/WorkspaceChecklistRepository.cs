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
    public class WorkspaceChecklistRepository : GenericRepository, IWorkspaceChecklistRepository
    {
        private IConfiguration _configuration;

        public WorkspaceChecklistRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveWorkspaceChecklist(WorkspaceChecklist_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@RequestNo", parameters.RequestNo);
            queryParameters.Add("@RequesterName", parameters.RequesterName);
            queryParameters.Add("@WorkLocation", parameters.WorkLocation);
            queryParameters.Add("@WorkDescription", parameters.WorkDescription);
            queryParameters.Add("@ApprovedById", parameters.ApprovedById);
            queryParameters.Add("@WorkPermitNo", parameters.WorkPermitNo);
            queryParameters.Add("@VendorName", parameters.VendorName);
            queryParameters.Add("@WorkExecutionDate", parameters.WorkExecutionDate);
            queryParameters.Add("@IsAfterWorkCleaning", parameters.IsAfterWorkCleaning);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveWorkspaceChecklist", queryParameters);
        }

        public async Task<IEnumerable<WorkspaceChecklist_Response>> GetWorkspaceChecklistList(WorkspaceChecklistSearch_Request parameters)
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

            var result = await ListByStoredProcedure<WorkspaceChecklist_Response>("GetWorkspaceChecklistList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<WorkspaceChecklist_Response?> GetWorkspaceChecklistById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<WorkspaceChecklist_Response>("GetWorkspaceChecklistById", queryParameters)).FirstOrDefault();
        }
    }
}
