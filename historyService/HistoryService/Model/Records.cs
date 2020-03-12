using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HistoryService.API.Model
{
    public class Records
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Uri { get; set; }

        public Records(string description, string userId,string uri)
        {
            Uri = uri;
            Description = description;
            UserId = userId;
        }
    }
}
