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
    public class CCTVMonitoringRepository : GenericRepository, ICCTVMonitoringRepository
    {
        private IConfiguration _configuration;

        public CCTVMonitoringRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveCCTVMonitoring(CCTVMonitoring_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@CCTVMonitoringDate", parameters.CCTVMonitoringDate);
            queryParameters.Add("@DvmServerId", parameters.DvmServerId);
            queryParameters.Add("@EbiServerId", parameters.EbiServerId);
            queryParameters.Add("@IsTimeSync", parameters.IsTimeSync);
            queryParameters.Add("@DiffBWSyncTime", parameters.DiffBWSyncTime);
            queryParameters.Add("@SyncDiffResolvedDate", parameters.SyncDiffResolvedDate);
            queryParameters.Add("@IsTimeSyncOnDifferenceResolved", parameters.IsTimeSyncOnDifferenceResolved);
            queryParameters.Add("@IsCCTV1_FeedCheck", parameters.IsCCTV1_FeedCheck);
            queryParameters.Add("@IsCCTV2_FeedCheck", parameters.IsCCTV2_FeedCheck);
            queryParameters.Add("@IsCCTV3_FeedCheck", parameters.IsCCTV3_FeedCheck);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveCCTVMonitoring", queryParameters);
        }

        public async Task<IEnumerable<CCTVMonitoring_Response>> GetCCTVMonitoringList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<CCTVMonitoring_Response>("GetCCTVMonitoringList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<CCTVMonitoring_Response?> GetCCTVMonitoringById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<CCTVMonitoring_Response>("GetCCTVMonitoringById", queryParameters)).FirstOrDefault();
        }
    }
}
