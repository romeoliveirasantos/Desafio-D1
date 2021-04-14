using ClientesDB.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesDB.Models
{
    public class ClienteContexto
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ClienteContexto(IOptions<ConfigDB> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);
            
            if(mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<Cliente> Clientes
        {
            get
            {
                return _mongoDatabase.GetCollection<Cliente>("Clientes");
            }
        }
    }
}
