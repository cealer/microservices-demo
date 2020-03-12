using HistoryService.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HistoryService.API.Infrastructure.Services
{
    public interface IRecordsService
    {
        Task<List<Records>> GetRecordsAsync(int skip = 0, int limit = 50);

        Task<List<Records>> GetRecordsByUserAsync(string userId);

        Task<bool> AddRecordsAsync(Records records);
    }
}
