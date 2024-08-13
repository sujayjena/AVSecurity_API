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
    public class MaterialInwardReturnableRepository : GenericRepository, IMaterialInwardReturnableRepository
    {
        private IConfiguration _configuration;

        public MaterialInwardReturnableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Material Inward  Returnanble
        public async Task<int> SaveMaterialInwardReturnable(MaterialInwardReturnable_Request parameters)
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
            queryParameters.Add("@ReturnableDate", parameters.ReturnableDate);
            queryParameters.Add("@MaterialStatusId", parameters.MaterialStatusId);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialInwardReturnable", queryParameters);
        }

        public async Task<IEnumerable<MaterialInwardReturnable_Response>> GetMaterialInwardReturnableList(MaterialInwardReturnableSearch_Request parameters)
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

            var result = await ListByStoredProcedure<MaterialInwardReturnable_Response>("GetMaterialInwardReturnableList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<MaterialInwardReturnable_Response?> GetMaterialInwardReturnableById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<MaterialInwardReturnable_Response>("GetMaterialInwardReturnableById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Material Inward  Returnanble Challan
        public async Task<int> SaveMaterialInwardReturnableChallan(MaterialInwardReturnableChallan_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@MaterialInwardReturnableId", parameters.MaterialInwardReturnableId);
            queryParameters.Add("@ChallanNumber", parameters.ChallanNumber);
            queryParameters.Add("@ChallanOriginalFileName", parameters.ChallanOriginalFileName);
            queryParameters.Add("@ChallanImage", parameters.ChallanImage);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialInwardReturnableChallan", queryParameters);
        }

        public async Task<IEnumerable<MaterialInwardReturnableChallan_Response>> GetMaterialInwardReturnableChallanList(MaterialInwardReturnableChallanSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@MaterialInwardReturnableId", parameters.MaterialInwardReturnableId);
            //queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MaterialInwardReturnableChallan_Response>("GetMaterialInwardReturnableChallanList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion
    }
}
