using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MMASystem.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Fingerprint { get; set; }
        [BsonIgnore]
        public object FingerprintReceiver { get; set; }
        public string Cargo { get; set; }
    }
}