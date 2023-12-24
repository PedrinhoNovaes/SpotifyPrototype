using SpotifyPrototype.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Transaction.ValueObject
{
    public class Merchant : Entity
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public Value Price { get; set; }

        public Merchant()
        {
            Price = new Value(0); 
        }

        public Merchant(string name, string cnpj, Value price) : base()
        {
            Name = name;
            CNPJ = cnpj;
            Price = price;
        }
    }
}