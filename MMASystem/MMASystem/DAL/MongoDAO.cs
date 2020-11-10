using MMASystem.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MMASystem.DAL
{
    public class MongoDAO
    {
        public IMongoCollection<User> Collection { get; set; }
        public MongoDAO()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoConnectionString"]);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);

            Collection = database.GetCollection<User>(ConfigurationManager.AppSettings["MongoCollection"]);
        }

        public void Create(User user)
        {
            try
            {
                Collection.InsertOne(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> Read()
        {
            try
            {
                return Collection.Find<User>(x => x.Fingerprint != null).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}