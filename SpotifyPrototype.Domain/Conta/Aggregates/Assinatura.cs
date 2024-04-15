using SpotifyPrototype.Domain.Core.Enum;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Domain.Streaming.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Conta.Aggregates
{
    public class Assinatura
    {
        public Guid Id { get; set; }
        public virtual Plano Plano { get; set; }
        public TipoStatus Status { get; set; }
        public Periodo Vigencia { get; set; }

        public void Inativar()
        {
            Status = TipoStatus.Inativo;
            Vigencia.FinalizaPeriodo(DateTime.Now);
        }

        public static Assinatura Criar(Plano plano, DateTime DataInicio)
        {
            if (plano.Status == TipoStatus.Inativo)
            {
                throw new Exception("O plano deve estar ativo para criar uma nova assinatura");
            }

            return new Assinatura()
            {
                Plano = plano,
                Status = TipoStatus.Ativo,
                Vigencia = Periodo.Criar(DataInicio, DataInicio.AddDays(30))
            };
        }
    }
}
