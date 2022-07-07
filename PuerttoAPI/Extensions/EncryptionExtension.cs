using Core.Puertto.Extensions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace PuerttoAPI.Extensions
{
    public static class EncryptionExtension
    {
        public static Encryption EncrypcioPassword(string password)
        {
            var keyunique = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(keyunique);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, keyunique, KeyDerivationPrf.HMACSHA256, 10000, (256 / 8)));
            return new Encryption() { Password = hashed, KeySecret = Convert.ToBase64String(keyunique) };
        }

        /// <summary>
        /// Validar Contraseña ingresada con la registrada
        /// </summary>
        /// <param name="passwwordEntered">Contraseña Ingeresada</param>
        /// <param name="passwwordRegistered">Contraseña Registrada</param>
        /// <param name="keySecret">Clave Secreta</param>
        /// <returns></returns>
        public static bool ValidatePassword(string passwwordEntered, string passwwordRegistered, string keySecret) 
            => passwwordRegistered.Equals(Convert.ToBase64String(KeyDerivation.Pbkdf2(passwwordEntered, Convert.FromBase64String(keySecret), KeyDerivationPrf.HMACSHA256, 10000, (256 / 8))));

    }
}
