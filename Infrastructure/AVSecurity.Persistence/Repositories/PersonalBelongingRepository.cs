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
    public class PersonalBelongingRepository : GenericRepository, IPersonalBelongingRepository
    {
        private IConfiguration _configuration;

        public PersonalBelongingRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SavePersonalBelonging(PersonalBelonging_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@PBBelongsToId", parameters.PBBelongsToId);
            queryParameters.Add("@PBTypeId", parameters.PBTypeId);
            queryParameters.Add("@PBDesc", parameters.PBDesc);
            queryParameters.Add("@PigeonSlotNumber", parameters.PigeonSlotNumber);
            queryParameters.Add("@PBReturnDate", parameters.PBReturnDate);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SavePersonalBelonging", queryParameters);
        }

        public async Task<IEnumerable<PersonalBelonging_Response>> GetPersonalBelongingList(PersonalBelongingSearch_Request parameters)
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

            var result = await ListByStoredProcedure<PersonalBelonging_Response>("GetPersonalBelongingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<PersonalBelonging_Response?> GetPersonalBelongingById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<PersonalBelonging_Response>("GetPersonalBelongingById", queryParameters)).FirstOrDefault();
        }
    }
}
