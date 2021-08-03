using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PBuilders.Domain.BynarySearchTree.Entity;

namespace PBuilders.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/bynary-search-tree")]
    public class BynarySearchTreeController : ControllerBase
    {
        private readonly IMongoCollection<Tree> _trees;

        public BynarySearchTreeController()
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_SERVER"));
            var database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));

            _trees = database.GetCollection<Tree>("tree");
        }

        [Route("get-node-by-value/{{value}}")]
        [HttpGet]
        public ActionResult GetNodeByValue([FromQuery] int value)
        {
            var tree = _trees.Find(FilterDefinition<Tree>.Empty).First();
            var node = tree.GetNodeByValue(tree.Root, value);

            return Ok(node);
        }
    }
}