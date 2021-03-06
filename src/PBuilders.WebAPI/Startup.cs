using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using PBuilders.Domain.BynarySearchTree.Entity;

namespace PBuilders.WebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PBuilders.WebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PBuilders.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DBInicializer();
        }

        private void DBInicializer()
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_SERVER"));
            var database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));
            var collection = database.GetCollection<Tree>("tree");

            if (collection.CountDocuments(FilterDefinition<Tree>.Empty) == 0)
            {
                var newTree = new Tree().GenerateRandomTree();
                collection.InsertOne(newTree);
            }
        }
    }
}
