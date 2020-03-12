using System.Collections.Generic;
using System.Threading.Tasks;
using HistoryService.API.Infrastructure.Repositories;
using HistoryService.API.Model;

namespace HistoryService.API.Infrastructure.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly IRecordRepository _recordsRepository;

        public RecordsService(IRecordRepository recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }

        public async Task<bool> AddRecordsAsync(Records records)
        {
            return await _recordsRepository.AddRecordsAsync(records);
        }

        public async Task<List<Records>> GetRecordsAsync(int skip = 0, int limit = 50)
        {
            return await _recordsRepository.GetRecordsAsync(skip, limit);
        }

        public async Task<List<Records>> GetRecordsByUserAsync(string userId)
        {
            return await _recordsRepository.GetRecordsByUserAsync(userId);
        }
    }
}
