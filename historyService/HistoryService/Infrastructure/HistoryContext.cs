using HistoryService.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HistoryService.API.Infrastructure
{
    public class HistoryContext
    {
        private readonly IMongoDatabase _database = null;

        public HistoryContext(IOptions<HistorySettings> settings)
        {
            var client = new MongoClient(settings.Value.MongoDBUri);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Records> Records
        {
            get
            {
                return _database.GetCollection<Records>("Records");
            }
        }

    }
}
