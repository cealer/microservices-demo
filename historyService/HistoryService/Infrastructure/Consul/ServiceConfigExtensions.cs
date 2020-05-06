using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryService.API.Infrastructure.Consul
{
    public static class ServiceConfigExtensions
    {
        public static ConsulConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ConsulConfig
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ConsulConfig:serviceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ConsulConfig:serviceAddress"),
                ServiceName = configuration.GetValue<string>("ConsulConfig:serviceName"),
                ServiceId = configuration.GetValue<string>("ConsulConfig:serviceId"),
                Tags = configuration.GetSection("ConsulConfig:tags").Get<string[]>()
            };

            return serviceConfig;
        }
    }
}
