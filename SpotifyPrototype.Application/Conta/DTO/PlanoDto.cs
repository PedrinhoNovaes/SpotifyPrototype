﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Conta.DTO
{
    public struct PlanoDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
