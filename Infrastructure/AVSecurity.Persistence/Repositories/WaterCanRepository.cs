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
    public class WaterCanRepository : GenericRepository, IWaterCanRepository
    {
        private IConfiguration _configuration;

        public WaterCanRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveWaterCan(WaterCan_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@ServiceProvider", parameters.ServiceProvider);
            queryParameters.Add("@DeliveryPersonName", parameters.DeliveryPersonName);
            queryParameters.Add("@DeliveryPersonMobileNo", parameters.DeliveryPersonMobileNo);
            queryParameters.Add("@NoOfWaterCanDelivered", parameters.NoOfWaterCanDelivered);
            queryParameters.Add("@NoOfWaterEmptyCanTaken", parameters.NoOfWaterEmptyCanTaken);
            queryParameters.Add("@IsNotificationToAdmin", parameters.IsNotificationToAdmin);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveWaterCan", queryParameters);
        }

        public async Task<IEnumerable<WaterCan_Response>> GetWaterCanList(WaterCanSearch_Request parameters)
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

            var result = await ListByStoredProcedure<WaterCan_Response>("GetWaterCanList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<WaterCan_Response?> GetWaterCanById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<WaterCan_Response>("GetWaterCanById", queryParameters)).FirstOrDefault();
        }
    }
}
