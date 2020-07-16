using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Commander.Models {
    public class Command {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string HowTo { get; set; }

        [BsonRequired]
        public string Line { get; set; }

        [BsonRequired]
        public string Platform { get; set; }        
    }
}
