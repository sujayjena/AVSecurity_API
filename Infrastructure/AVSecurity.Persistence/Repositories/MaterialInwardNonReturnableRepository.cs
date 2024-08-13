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
    public class MaterialInwardNonReturnableRepository : GenericRepository, IMaterialInwardNonReturnableRepository
    {
        private IConfiguration _configuration;

        public MaterialInwardNonReturnableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Material Inward Non Returnanble
        public async Task<int> SaveMaterialInwardNonReturnable(MaterialInwardNonReturnable_Request parameters)
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

            return await SaveByStoredProcedure<int>("SaveMaterialInwardNonReturnable", queryParameters);
        }

        public async Task<IEnumerable<MaterialInwardNonReturnable_Response>> GetMaterialInwardNonReturnableList(MaterialInwardNonReturnableSearch_Request parameters)
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

            var result = await ListByStoredProcedure<MaterialInwardNonReturnable_Response>("GetMaterialInwardNonReturnableList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<MaterialInwardNonReturnable_Response?> GetMaterialInwardNonReturnableById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<MaterialInwardNonReturnable_Response>("GetMaterialInwardNonReturnableById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Material Inward Non Returnanble Challan
        public async Task<int> SaveMaterialInwardNonReturnableChallan(MaterialInwardNonReturnableChallan_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@MaterialInwardNonReturnableId", parameters.MaterialInwardNonReturnableId);
            queryParameters.Add("@ChallanNumber", parameters.ChallanNumber);
            queryParameters.Add("@ChallanOriginalFileName", parameters.ChallanOriginalFileName);
            queryParameters.Add("@ChallanImage", parameters.ChallanImage);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialInwardNonReturnableChallan", queryParameters);
        }

        public async Task<IEnumerable<MaterialInwardNonReturnableChallan_Response>> GetMaterialInwardNonReturnableChallanList(MaterialInwardNonReturnableChallanSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@MaterialInwardNonReturnableId", parameters.MaterialInwardNonReturnableId);
            //queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MaterialInwardNonReturnableChallan_Response>("GetMaterialInwardNonReturnableChallanList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion
    }
}
