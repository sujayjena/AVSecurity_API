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
    public class IncomingCourierRepository : GenericRepository, IIncomingCourierRepository
    {
        private IConfiguration _configuration;

        public IncomingCourierRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveIncomingCourier(IncomingCourier_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@FromCompany", parameters.FromCompany);
            queryParameters.Add("@Address", parameters.Address);
            queryParameters.Add("@FromCity", parameters.FromCity);
            queryParameters.Add("@Pincode", parameters.Pincode);
            queryParameters.Add("@CourierName", parameters.CourierName);
            queryParameters.Add("@AirwayBillNo", parameters.AirwayBillNo);
            queryParameters.Add("@IsNotifyToEmployee", parameters.IsNotifyToEmployee);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveIncomingCourier", queryParameters);
        }

        public async Task<IEnumerable<IncomingCourier_Response>> GetIncomingCourierList(IncomingCourierSearch_Request parameters)
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

            var result = await ListByStoredProcedure<IncomingCourier_Response>("GetIncomingCourierList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<IncomingCourier_Response?> GetIncomingCourierById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<IncomingCourier_Response>("GetIncomingCourierById", queryParameters)).FirstOrDefault();
        }
    }
}
