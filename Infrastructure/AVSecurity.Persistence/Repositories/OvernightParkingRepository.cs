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
    public class OvernightParkingRepository : GenericRepository, IOvernightParkingRepository
    {
        private IConfiguration _configuration;

        public OvernightParkingRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveOvernightParking(OvernightParking_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@VehicleTypeId", parameters.VehicleTypeId);
            queryParameters.Add("@VehicleNo", parameters.VehicleNo);
            queryParameters.Add("@VehicleCondition", parameters.VehicleCondition);
            queryParameters.Add("@ParkedArea", parameters.ParkedArea);
            queryParameters.Add("@IsNotificationToAdmin", parameters.IsNotificationToAdmin);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOvernightParking", queryParameters);
        }

        public async Task<IEnumerable<OvernightParking_Response>> GetOvernightParkingList(OvernightParkingSearch_Request parameters)
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

            var result = await ListByStoredProcedure<OvernightParking_Response>("GetOvernightParkingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<OvernightParking_Response?> GetOvernightParkingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<OvernightParking_Response>("GetOvernightParkingById", queryParameters)).FirstOrDefault();
        }
    }
}
