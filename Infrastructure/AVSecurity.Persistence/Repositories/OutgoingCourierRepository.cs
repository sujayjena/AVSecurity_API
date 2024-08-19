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
    public class OutgoingCourierRepository : GenericRepository, IOutgoingCourierRepository
    {
        private IConfiguration _configuration;

        public OutgoingCourierRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveOutgoingCourier(OutgoingCourier_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@ToCompany", parameters.ToCompany);
            queryParameters.Add("@Address", parameters.Address);
            queryParameters.Add("@ToCity", parameters.ToCity);
            queryParameters.Add("@Pincode", parameters.Pincode);
            queryParameters.Add("@CourierNameId", parameters.CourierNameId);
            queryParameters.Add("@AirwayBillNo", parameters.AirwayBillNo);
            queryParameters.Add("@DispatchedDate", parameters.DispatchedDate);
            queryParameters.Add("@IsNotificationToAdmin", parameters.IsNotificationToAdmin);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOutgoingCourier", queryParameters);
        }

        public async Task<IEnumerable<OutgoingCourier_Response>> GetOutgoingCourierList(OutgoingCourierSearch_Request parameters)
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

            var result = await ListByStoredProcedure<OutgoingCourier_Response>("GetOutgoingCourierList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<OutgoingCourier_Response?> GetOutgoingCourierById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<OutgoingCourier_Response>("GetOutgoingCourierById", queryParameters)).FirstOrDefault();
        }
    }
}
