using HistoryService.API.IntegrationEvents.Events;
using HistoryService.API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceStack.Redis;

namespace HistoryService.API.Infrastructure.Services
{
    public class RecordEventsService : IRecordEventsService
    {
        private readonly string ChannelName = null;
        private readonly IRedisClient _redis;

        public RecordEventsService(IConfiguration configuration, IRedisClient redisClient)
        {
            _redis = redisClient;
            ChannelName = configuration["redis:channel"];
        }

        public void PublishNewRecordCreated(Records records)
        {
            var message = new Message(records.Id, records.Description, records.UserId, records.Uri);
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var payload = JsonConvert.SerializeObject(records, Formatting.Indented, settings);
            _redis.PublishMessage(ChannelName, payload);
        }
    }
}
