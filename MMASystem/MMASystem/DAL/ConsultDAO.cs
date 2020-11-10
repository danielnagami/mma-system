using MMASystem.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MMASystem.DAL
{
    public class ConsultDAO
    {
        public IMongoCollection<Properties> Collection { get; set; }
        public ConsultDAO()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoConnectionString"]);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);

            Collection = database.GetCollection<Properties>(ConfigurationManager.AppSettings["MongoCollectionConsult"]);
        }

        public void Create(Properties properties)
        {
            try
            {
                Collection.InsertOne(properties);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Properties> Read()
        {
            try
            {
                return Collection.Find<Properties>(x => x.Nome != null).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}