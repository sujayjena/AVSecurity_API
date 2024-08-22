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
    public class PAChecklistRepository : GenericRepository, IPAChecklistRepository
    {
        private IConfiguration _configuration;

        public PAChecklistRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SavePAChecklist(PAChecklist_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@LocationId", parameters.LocationId);
            queryParameters.Add("@BuildingId", parameters.BuildingId);
            queryParameters.Add("@FloorId", parameters.FloorId);
            queryParameters.Add("@Audibility_WS_Area", parameters.Audibility_WS_Area);
            queryParameters.Add("@ReportedToId", parameters.ReportedToId);
            queryParameters.Add("@RectificationDate", parameters.RectificationDate);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SavePAChecklist", queryParameters);
        }

        public async Task<IEnumerable<PAChecklist_Response>> GetPAChecklistList(PAChecklistSearch_Request parameters)
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

            var result = await ListByStoredProcedure<PAChecklist_Response>("GetPAChecklistList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<PAChecklist_Response?> GetPAChecklistById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<PAChecklist_Response>("GetPAChecklistById", queryParameters)).FirstOrDefault();
        }
    }
}
