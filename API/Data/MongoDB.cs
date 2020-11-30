using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace API.Data
{
    public class MongoDb
    {
        public IMongoDatabase Db { get; }

        public MongoDb(IConfiguration config)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(config["ConnectionString"]));
                var client = new MongoClient(settings);
                Db = client.GetDatabase(config["Coronavirus"]);
                MapClassses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não é possível se conectar ao banco de dados.", ex);
            }
        }

        private void MapClassses()
        {
            // Define que o mapping utilizara o padrão CamelCase.
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            // Se não tivermos nenhuma classe mapeada, para esse tipo, iremos mapear.
            if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
            {
                BsonClassMap.RegisterClassMap<Infected>(i =>
                {
                    // Aqui podemos utilizar o MapField para definir configurações especificas
                    // o AutoMap efetua o mapeamento por convenção automaticamente.
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}