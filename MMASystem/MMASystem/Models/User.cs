using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MMASystem.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Fingerprint { get; set; }
        [BsonIgnore]
        public object FingerprintReceiver { get; set; }
        public IEnumerable<Cargos> Cargo { get; set; }
    }

    public enum Cargos
    {
        Todos,
        Diretor,
        Ministro
    }
}