namespace HistoryService.API
{
    public class HistorySettings
    {
        public string Database { get; set; }
        public string MongoDBUri { get; set; }
        public string RabbitmqURI { get; set; }
    }
}
