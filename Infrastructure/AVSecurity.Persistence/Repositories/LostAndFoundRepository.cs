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
    public class LostAndFoundRepository : GenericRepository, ILostAndFoundRepository
    {
        private IConfiguration _configuration;

        public LostAndFoundRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveLostAndFound(LostAndFound_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ShiftId", parameters.ShiftId);
            queryParameters.Add("@DateAndTime", parameters.DateAndTime);
            queryParameters.Add("@ItemName", parameters.ItemName);
            queryParameters.Add("@FoundByName", parameters.FoundByName);
            queryParameters.Add("@FoundLocation", parameters.FoundLocation);
            queryParameters.Add("@ItemHandoverDate", parameters.ItemHandoverDate);
            queryParameters.Add("@ReceiverId", parameters.ReceiverId);
            queryParameters.Add("@ReceiverIDNo", parameters.ReceiverIDNo);
            queryParameters.Add("@Remarks", parameters.Remarks);
            queryParameters.Add("@IsNotificationToAdmin", parameters.IsNotificationToAdmin);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLostAndFound", queryParameters);
        }

        public async Task<IEnumerable<LostAndFound_Response>> GetLostAndFoundList(LostAndFoundSearch_Request parameters)
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

            var result = await ListByStoredProcedure<LostAndFound_Response>("GetLostAndFoundList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<LostAndFound_Response?> GetLostAndFoundById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();

            queryParameters.Add("@Id", Id);

            return (await ListByStoredProcedure<LostAndFound_Response>("GetLostAndFoundById", queryParameters)).FirstOrDefault();
        }
    }
}
