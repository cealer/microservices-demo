namespace HistoryService.API.IntegrationEvents.Events
{
    public class RecordCreatedIntegrationEvent 
    {
        public string UserId { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
    }
}
