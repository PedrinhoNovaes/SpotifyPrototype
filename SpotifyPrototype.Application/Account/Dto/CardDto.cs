using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Account.Dto
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public decimal Limit { get; set; }
        public string Number { get; set; }
    }

}
