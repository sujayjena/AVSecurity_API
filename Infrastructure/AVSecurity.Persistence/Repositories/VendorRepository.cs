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
    public class VendorRepository : GenericRepository, IVendorRepository
    {
        private IConfiguration _configuration;

        public VendorRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveVendor(Vendor_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@VendorName", parameters.VendorName);
            queryParameters.Add("@PhoneNumber", parameters.PhoneNumber);
            queryParameters.Add("@MobileNo", parameters.MobileNo);
            queryParameters.Add("@VisitPurposeId", parameters.VisitPurposeId);
            queryParameters.Add("@BadgeNo", parameters.BadgeNo);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveVendor", queryParameters);
        }

        public async Task<IEnumerable<Vendor_Response>> GetVendorList(VendorSearch_Request parameters)
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

            var result = await ListByStoredProcedure<Vendor_Response>("GetVendorList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Vendor_Response?> GetVendorById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<Vendor_Response>("GetVendorById", queryParameters)).FirstOrDefault();
        }
    }
}
