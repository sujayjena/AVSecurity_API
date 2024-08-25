using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface ITempIDCardIssueRepository
    {
        Task<int> SaveTempIDCardIssue(TempIDCardIssue_Request parameters);

        Task<IEnumerable<TempIDCardIssue_Response>> GetTempIDCardIssueList(TempIDCardIssueSearch_Request parameters);

        Task<TempIDCardIssue_Response?> GetTempIDCardIssueById(int Id);
    }
}
