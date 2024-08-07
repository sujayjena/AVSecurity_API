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
    public class AccessDoorChecklistRepository : GenericRepository, IAccessDoorChecklistRepository
    {
        private IConfiguration _configuration;

        public AccessDoorChecklistRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveAccessDoorChecklist(AccessDoorChecklist_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@AccesDoorDate", parameters.AccesDoorDate);
            queryParameters.Add("@AccesDoorLocation", parameters.AccesDoorLocation);
            queryParameters.Add("@BuildingId", parameters.BuildingId);
            queryParameters.Add("@FloorId", parameters.FloorId);
            queryParameters.Add("@IsInReaderStatus", parameters.IsInReaderStatus);
            queryParameters.Add("@IsInPushButtonStatus", parameters.IsInPushButtonStatus);
            queryParameters.Add("@IsOutReaderStatus", parameters.IsOutReaderStatus);
            queryParameters.Add("@IsOutPushButtonStatus", parameters.IsOutPushButtonStatus);
            queryParameters.Add("@IsElectroMagneticLockStatus", parameters.IsElectroMagneticLockStatus);
            queryParameters.Add("@IsDoorAlignment", parameters.IsDoorAlignment);
            queryParameters.Add("@IsFaulty", parameters.IsFaulty);
            queryParameters.Add("@ExpenseDesc", parameters.ExpenseDesc);
            queryParameters.Add("@ReportedToId", parameters.ReportedToId);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveAccessDoorChecklist", queryParameters);
        }

        public async Task<IEnumerable<AccessDoorChecklist_Response>> GetAccessDoorChecklistList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<AccessDoorChecklist_Response>("GetAccessDoorChecklistList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<AccessDoorChecklist_Response?> GetAccessDoorChecklistById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<AccessDoorChecklist_Response>("GetAccessDoorChecklistById", queryParameters)).FirstOrDefault();
        }
    }
}
