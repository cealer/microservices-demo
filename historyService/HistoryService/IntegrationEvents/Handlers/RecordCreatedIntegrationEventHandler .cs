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
        private readonly IRecordEventsService _recordEventsService;

        public RecordCreatedIntegrationEventHandler(IRecordsService recordsService, IRecordEventsService recordEventsService)
        {
            _recordsService = recordsService;
            _recordEventsService = recordEventsService;
        }

        public async Task Consume(ConsumeContext<RecordCreatedIntegrationEvent> context)
        {
            var record = new Records(context.Message.Description, context.Message.UserId, context.Message.Uri);

            var result = await _recordsService.AddRecordsAsync(record);

            if (result)
            {
                _recordEventsService.PublishNewRecordCreated(record);
            }

        }
    }
}
