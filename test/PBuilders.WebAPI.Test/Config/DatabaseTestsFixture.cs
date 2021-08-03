using System;
using MongoDB.Driver;
using PBuilders.Domain.BynarySearchTree.Entity;

namespace PBuilders.WebAPI.Test.Config
{
    public class DatabaseTestsFixture
    {
        private readonly IMongoCollection<Tree> _trees;

        public DatabaseTestsFixture()
        {
            Environment.SetEnvironmentVariable("MONGODB_SERVER", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable("MONGODB_DATABASE", "pbuildersTest");

            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_SERVER"));
            var database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));

            _trees = database.GetCollection<Tree>("tree");
        }

        public void CreateTree(Tree tree)
        {
            _trees.InsertOne(tree);
        }
    }
}