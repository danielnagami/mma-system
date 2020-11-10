using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MMASystem.Models
{
    public class Properties
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string RiosAfetados { get; set; }
        public bool UsaAgrotóxico { get; set; }
    }
}