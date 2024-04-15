using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Conta.DTO
{
    public struct CartaoDto
    {
        public Guid Id { get; set; }
        public String Numero { get; set; }
        public String? CVV { get; set; }
        public String Estado { get; set; }
        public String Cidade { get; set; }
        public String Rua { get; set; }
        public String NumeroEndereco { get; set; }
        public String CEP { get; set; }
        public String? Complemento { get; set; }
    }
}
