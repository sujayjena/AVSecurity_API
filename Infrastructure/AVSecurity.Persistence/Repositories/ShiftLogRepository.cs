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
    public class ShiftLogRepository : GenericRepository, IShiftLogRepository
    {
        private IConfiguration _configuration;

        public ShiftLogRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveShiftLog(ShiftLog_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@HandedOverById", parameters.HandedOverById);
            queryParameters.Add("@HandedOverToId", parameters.HandedOverToId);
            queryParameters.Add("@IsCheckComplaintAndActionTaken", parameters.IsCheckComplaintAndActionTaken);
            queryParameters.Add("@IsCheckAllUPSParameters", parameters.IsCheckAllUPSParameters);
            queryParameters.Add("@IsCheckTransformerProperWorking", parameters.IsCheckTransformerProperWorking);
            queryParameters.Add("@IsCheckLightFitting", parameters.IsCheckLightFitting);
            queryParameters.Add("@IsCheckAllLTPanels", parameters.IsCheckAllLTPanels);
            queryParameters.Add("@IsCheckAllElevators", parameters.IsCheckAllElevators);
            queryParameters.Add("@IsCheckAirCompressorProperWorking", parameters.IsCheckAirCompressorProperWorking);
            queryParameters.Add("@IsCheckDGParameter", parameters.IsCheckDGParameter);
            queryParameters.Add("@IsCheckSwitchOnOffAllCommonAreaLight", parameters.IsCheckSwitchOnOffAllCommonAreaLight);
            queryParameters.Add("@IsRegulateFloorLighting", parameters.IsRegulateFloorLighting);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveShiftLog", queryParameters);
        }

        public async Task<IEnumerable<ShiftLog_Response>> GetShiftLogList(ShiftLogSearch_Request parameters)
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

            var result = await ListByStoredProcedure<ShiftLog_Response>("GetShiftLogList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<ShiftLog_Response?> GetShiftLogById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<ShiftLog_Response>("GetShiftLogById", queryParameters)).FirstOrDefault();
        }
    }
}
