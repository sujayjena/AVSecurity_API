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
    public class FoodDeliveryRepository : GenericRepository, IFoodDeliveryRepository
    {
        private IConfiguration _configuration;

        public FoodDeliveryRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveFoodDelivery(FoodDelivery_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@FoodDeliveryDate", parameters.FoodDeliveryDate);
            queryParameters.Add("@Name", parameters.Name);
            queryParameters.Add("@PhoneNumber", parameters.PhoneNumber);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@ShopName", parameters.ShopName);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveFoodDelivery", queryParameters);
        }

        public async Task<IEnumerable<FoodDelivery_Response>> GetFoodDeliveryList(FoodDeliverySearch_Request parameters)
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

            var result = await ListByStoredProcedure<FoodDelivery_Response>("GetFoodDeliveryList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<FoodDelivery_Response?> GetFoodDeliveryById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<FoodDelivery_Response>("GetFoodDeliveryById", queryParameters)).FirstOrDefault();
        }
    }
}
