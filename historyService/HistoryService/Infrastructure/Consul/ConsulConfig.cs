using System;

namespace HistoryService.API.Infrastructure.Consul
{
    public class ConsulConfig
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public string[] Tags { get; set; }
    }
}
