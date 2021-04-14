using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesDB.Models
{
    public class Cliente
    {
        [BsonElement("_id")]
        public Guid ClientId { get; set; }
        public string Nome { get; set; }

        public string Nascimento { get; set; }

        public string RG { get; set; } 
        
        public string CPF { get; set; }

        public string Endereço { get; set; }

        public string Contato { get; set; }

        public string Socials { get; set; }

    }
}
