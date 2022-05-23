using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Isopoh.Cryptography.Argon2;

namespace SuperMarketManagement.Application.Utilities.Security.Hashers
{
    public static class PasswordHasher
    {
        // must install B-Crypt.Net-Next in nuget packages
        #region BCrypt

        public static string HashWithBCrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyBCrypt(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        #endregion

        #region SHA256

        private static string HashWithSha256(string text)
        {
            // SHA512 is disposable by inheritance.  
            using var sha256 = SHA256.Create();
            
            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            
            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        #endregion

        // must install Isopoh.Cryptography.Argon2 in nuget packages
        #region aragon 2

        public static string HashWithAragon2(string password)
        {
            return Argon2.Hash(password);
        }
        
        #endregion
    }
}
