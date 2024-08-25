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
    public class VehicleEntryChecklistRepository : GenericRepository, IVehicleEntryChecklistRepository
    {
        private IConfiguration _configuration;

        public VehicleEntryChecklistRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveVehicleEntryChecklist(VehicleEntryChecklist_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@VehicleTypeId", parameters.VehicleTypeId);
            queryParameters.Add("@VehicleNumber", parameters.VehicleNumber);
            queryParameters.Add("@OutDate", parameters.OutDate);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveVehicleEntryChecklist", queryParameters);
        }

        public async Task<IEnumerable<VehicleEntryChecklist_Response>> GetVehicleEntryChecklistList(VehicleEntryChecklistSearch_Request parameters)
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

            var result = await ListByStoredProcedure<VehicleEntryChecklist_Response>("GetVehicleEntryChecklistList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<VehicleEntryChecklist_Response?> GetVehicleEntryChecklistById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<VehicleEntryChecklist_Response>("GetVehicleEntryChecklistById", queryParameters)).FirstOrDefault();
        }
    }
}
