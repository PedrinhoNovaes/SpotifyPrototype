﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Core.ValueObject
{
    public record Monetario
    {
        public decimal Valor { get; set; }

        public Monetario()
        {

        }

        public Monetario(decimal valor)
        {
            if (valor < 0)
            {
                throw new Exception("Valor monteário não pode ser negativo.");
            }

            Valor = valor;
        }

        public string Formatado()
        {
            return $"{Valor:N2}";
        }

        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new Monetario(valor);
    }
}
