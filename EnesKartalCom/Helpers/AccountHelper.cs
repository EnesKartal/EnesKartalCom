using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace EnesKartalCom
{
    public class AccountHelper
    {
        public static string HashPassword(string password, string secret)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(secret);

            byte[] hashBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 256 / 8
            );
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
        public static bool VerifyHashedPassword(string modelPassword, string userPassword, string secret)
        {
            string hashedPassword = HashPassword(modelPassword, secret);
            return userPassword == hashedPassword;
        }
    }
}
