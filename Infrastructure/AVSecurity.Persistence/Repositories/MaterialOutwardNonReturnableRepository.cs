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
    public class MaterialOutwardNonReturnableRepository : GenericRepository, IMaterialOutwardNonReturnableRepository
    {
        private IConfiguration _configuration;

        public MaterialOutwardNonReturnableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Material Outward Non Returnanble
        public async Task<int> SaveMaterialOutwardNonReturnable(MaterialOutwardNonReturnable_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@SenderCompanyName", parameters.SenderCompanyName);
            queryParameters.Add("@SenderName", parameters.SenderName);
            queryParameters.Add("@Address", parameters.Address);
            queryParameters.Add("@TransporterCompanyName", parameters.TransporterCompanyName);
            queryParameters.Add("@NatureOfSupply", parameters.NatureOfSupply);
            queryParameters.Add("@PONumber", parameters.PONumber);
            queryParameters.Add("@MaterialName", parameters.MaterialName);
            queryParameters.Add("@Quantity", parameters.Quantity);
            queryParameters.Add("@Serialno", parameters.Serialno);
            queryParameters.Add("@Assetno", parameters.Assetno);
            queryParameters.Add("@MaterialStatusId", parameters.MaterialStatusId);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialOutwardNonReturnable", queryParameters);
        }

        public async Task<IEnumerable<MaterialOutwardNonReturnable_Response>> GetMaterialOutwardNonReturnableList(MaterialOutwardNonReturnableSearch_Request parameters)
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

            var result = await ListByStoredProcedure<MaterialOutwardNonReturnable_Response>("GetMaterialOutwardNonReturnableList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<MaterialOutwardNonReturnable_Response?> GetMaterialOutwardNonReturnableById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<MaterialOutwardNonReturnable_Response>("GetMaterialOutwardNonReturnableById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Material Outward Non Returnanble Challan
        public async Task<int> SaveMaterialOutwardNonReturnableChallan(MaterialOutwardNonReturnableChallan_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@MaterialOutwardNonReturnableId", parameters.MaterialOutwardNonReturnableId);
            queryParameters.Add("@ChallanNumber", parameters.ChallanNumber);
            queryParameters.Add("@ChallanOriginalFileName", parameters.ChallanOriginalFileName);
            queryParameters.Add("@ChallanImage", parameters.ChallanImage);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialOutwardNonReturnableChallan", queryParameters);
        }

        public async Task<IEnumerable<MaterialOutwardNonReturnableChallan_Response>> GetMaterialOutwardNonReturnableChallanList(MaterialOutwardNonReturnableChallanSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@MaterialOutwardNonReturnableId", parameters.MaterialOutwardNonReturnableId);
            //queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MaterialOutwardNonReturnableChallan_Response>("GetMaterialOutwardNonReturnableChallanList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion
    }
}
