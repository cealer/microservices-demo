using HistoryService.API.Infrastructure.Services;
using HistoryService.API.IntegrationEvents.Events;
using HistoryService.API.Model;
using MassTransit;
using System.Threading.Tasks;

namespace HistoryService.API.IntegrationEvents.Handlers
{
    public class RecordCreatedIntegrationEventHandler :
        IConsumer<RecordCreatedIntegrationEvent>
    {
        private readonly IRecordsService _recordsService;

        public RecordCreatedIntegrationEventHandler(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }

        public async Task Consume(ConsumeContext<RecordCreatedIntegrationEvent> context)
        {
            var record = new Records(context.Message.Description, context.Message.UserId, context.Message.Uri);
            await _recordsService.AddRecordsAsync(record);
        }
    }
}
