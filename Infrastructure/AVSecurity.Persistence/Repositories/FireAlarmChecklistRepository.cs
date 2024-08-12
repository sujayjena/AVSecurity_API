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
    public class FireAlarmChecklistRepository : GenericRepository, IFireAlarmChecklistRepository
    {
        private IConfiguration _configuration;

        public FireAlarmChecklistRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveFireAlarmChecklist(FireAlarmChecklist_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@LocationId", parameters.LocationId);
            queryParameters.Add("@BuildingId", parameters.BuildingId);
            queryParameters.Add("@FloorId", parameters.FloorId);
            queryParameters.Add("@LoopDeviceNumber", parameters.LoopDeviceNumber);
            queryParameters.Add("@Sounder", parameters.Sounder);
            queryParameters.Add("@Display", parameters.Display);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@VerifiedId", parameters.VerifiedId);
            queryParameters.Add("@VerifiedDate", parameters.VerifiedDate);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveFireAlarmChecklist", queryParameters);
        }

        public async Task<IEnumerable<FireAlarmChecklist_Response>> GetFireAlarmChecklistList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<FireAlarmChecklist_Response>("GetFireAlarmChecklistList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<FireAlarmChecklist_Response?> GetFireAlarmChecklistById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<FireAlarmChecklist_Response>("GetFireAlarmChecklistById", queryParameters)).FirstOrDefault();
        }
    }
}
