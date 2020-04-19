using HistoryService.API.Model;

namespace HistoryService.API.Infrastructure.Services
{
    public interface IRecordEventsService
    {
        void PublishNewRecordCreated(Records records);
    }
}
