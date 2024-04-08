using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Core.Extension
{
    public static class EncryptionExtension
    {
        public static string HashSHA256(this string plainText)
        {
            SHA256 cryptoProvider = SHA256.Create();

            byte[] textBytes = Encoding.UTF8.GetBytes(plainText);

            var cryptoResult = cryptoProvider.ComputeHash(textBytes);

            return Convert.ToHexString(cryptoResult);
        }
    }

}
