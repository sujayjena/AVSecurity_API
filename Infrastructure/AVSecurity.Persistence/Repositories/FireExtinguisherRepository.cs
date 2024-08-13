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
    public class FireExtinguisherRepository : GenericRepository, IFireExtinguisherRepository
    {
        private IConfiguration _configuration;

        public FireExtinguisherRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveFireExtinguisher(FireExtinguisher_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@FireEDate", parameters.FireEDate);
            queryParameters.Add("@EmployeeId", parameters.EmployeeId);
            queryParameters.Add("@PhoneNumber", parameters.PhoneNumber);
            queryParameters.Add("@FireELocation", parameters.FireELocation);
            queryParameters.Add("@InspectedById", parameters.InspectedById);
            queryParameters.Add("@InformedToId", parameters.InformedToId);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveFireExtinguisher", queryParameters);
        }

        public async Task<IEnumerable<FireExtinguisher_Response>> GetFireExtinguisherList(FireExtinguisherSearch_Request parameters)
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

            var result = await ListByStoredProcedure<FireExtinguisher_Response>("GetFireExtinguisherList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<FireExtinguisher_Response?> GetFireExtinguisherById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<FireExtinguisher_Response>("GetFireExtinguisherById", queryParameters)).FirstOrDefault();
        }
    }
   
}
