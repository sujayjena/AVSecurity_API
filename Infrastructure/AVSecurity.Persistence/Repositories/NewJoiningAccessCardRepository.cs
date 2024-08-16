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
    public class NewJoiningAccessCardRepository : GenericRepository, INewJoiningAccessCardRepository
    {
        private IConfiguration _configuration;

        public NewJoiningAccessCardRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveNewJoiningAccessCard(NewJoiningAccessCard_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@FirstName", parameters.FirstName);
            queryParameters.Add("@LastName", parameters.LastName);
            queryParameters.Add("@EID", parameters.EID);
            queryParameters.Add("@BloodGroupId", parameters.BloodGroupId);
            queryParameters.Add("@EmployeeTypeId", parameters.EmployeeTypeId);
            queryParameters.Add("@GenderId", parameters.GenderId);
            queryParameters.Add("@IDNo", parameters.IDNo);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveNewJoiningAccessCard", queryParameters);
        }

        public async Task<IEnumerable<NewJoiningAccessCard_Response>> GetNewJoiningAccessCardList(NewJoiningAccessCardSearch_Request parameters)
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

            var result = await ListByStoredProcedure<NewJoiningAccessCard_Response>("GetNewJoiningAccessCardList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<NewJoiningAccessCard_Response?> GetNewJoiningAccessCardById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<NewJoiningAccessCard_Response>("GetNewJoiningAccessCardById", queryParameters)).FirstOrDefault();
        }
    }
}
