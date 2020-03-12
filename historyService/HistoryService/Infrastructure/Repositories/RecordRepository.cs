using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HistoryService.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HistoryService.API.Infrastructure.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly HistoryContext _context;

        public RecordRepository(IOptions<HistorySettings> settings)
        {
            _context = new HistoryContext(settings);
        }

        public async Task<bool> AddRecordsAsync(Records records)
        {
            try
            {
                await _context.Records.InsertOneAsync(records);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Records>> GetRecordsAsync(int skip = 0, int limit = 50)
        {
            return await _context.Records.Find(x => true).Skip(skip).Limit(limit).ToListAsync();
        }

        public async Task<List<Records>> GetRecordsByUserAsync(string userId, int skip = 0, int limit = 50)
        {
            var filter = Builders<Records>.Filter.Eq("UserId", userId);
            return await _context.Records
                                 .Find(filter)
                                 .Skip(skip)
                                 .Limit(limit)
                                 .ToListAsync();
        }

    }
}
