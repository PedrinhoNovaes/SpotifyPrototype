using SpotifyPrototype.Application.Conta.DTO;
using SpotifyPrototype.Domain.Transacao.Aggregates;
using SpotifyPrototype.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Conta
{
    public class CartaoService
    {
        public Cartao ConsultarCartaoAtivo(CartaoDto cartaoDto)
        {
            Endereco enderecoCobranca = Endereco.Criar(cartaoDto.Estado, cartaoDto.Cidade, cartaoDto.Rua,
                cartaoDto.NumeroEndereco, cartaoDto.CEP, cartaoDto.Complemento);

            return new()
            {
                EnderecoCobranca = enderecoCobranca,
                Limite = 500,
                Status = Domain.Core.Enum.TipoStatus.Ativo,
                Numero = cartaoDto.Numero,
                CVV = cartaoDto.CVV ?? string.Empty
            };
        }
    }
}
