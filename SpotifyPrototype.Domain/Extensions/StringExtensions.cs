using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SpotifyPrototype.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Criptografar(this string valor)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] texto = Encoding.UTF8.GetBytes(valor);

            var criptoResult = criptoProvider.ComputeHash(texto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
