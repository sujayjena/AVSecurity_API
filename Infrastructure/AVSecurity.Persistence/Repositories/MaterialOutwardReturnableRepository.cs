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
    public class MaterialOutwardReturnableRepository : GenericRepository, IMaterialOutwardReturnableRepository
    {
        private IConfiguration _configuration;

        public MaterialOutwardReturnableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Material Outward  Returnanble
        public async Task<int> SaveMaterialOutwardReturnable(MaterialOutwardReturnable_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@ReceiverCompanyName", parameters.ReceiverCompanyName);
            queryParameters.Add("@ReceiverName", parameters.ReceiverName);
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

            return await SaveByStoredProcedure<int>("SaveMaterialOutwardReturnable", queryParameters);
        }

        public async Task<IEnumerable<MaterialOutwardReturnable_Response>> GetMaterialOutwardReturnableList(MaterialOutwardReturnableSearch_Request parameters)
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

            var result = await ListByStoredProcedure<MaterialOutwardReturnable_Response>("GetMaterialOutwardReturnableList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<MaterialOutwardReturnable_Response?> GetMaterialOutwardReturnableById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<MaterialOutwardReturnable_Response>("GetMaterialOutwardReturnableById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Material Outward  Returnanble Challan
        public async Task<int> SaveMaterialOutwardReturnableChallan(MaterialOutwardReturnableChallan_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@MaterialOutwardReturnableId", parameters.MaterialOutwardReturnableId);
            queryParameters.Add("@ChallanNumber", parameters.ChallanNumber);
            queryParameters.Add("@ChallanOriginalFileName", parameters.ChallanOriginalFileName);
            queryParameters.Add("@ChallanImage", parameters.ChallanImage);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveMaterialOutwardReturnableChallan", queryParameters);
        }

        public async Task<IEnumerable<MaterialOutwardReturnableChallan_Response>> GetMaterialOutwardReturnableChallanList(MaterialOutwardReturnableChallanSearch_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@MaterialOutwardReturnableId", parameters.MaterialOutwardReturnableId);
            //queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            //queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<MaterialOutwardReturnableChallan_Response>("GetMaterialOutwardReturnableChallanList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }
        #endregion
    }
}
