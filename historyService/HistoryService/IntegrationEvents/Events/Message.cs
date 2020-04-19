using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryService.API.IntegrationEvents.Events
{
    public class Message
    {
        public Message(string id, string description, string userId, string uri)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Uri { get; set; }
    }
}
