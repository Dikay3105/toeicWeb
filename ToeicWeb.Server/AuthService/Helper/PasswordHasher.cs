﻿using System.Security.Cryptography;
using System.Text;

namespace ToeicWeb.Server.Helpers
{
    public static class PasswordHasher
    {
        // Hashes the password with a unique salt
        public static (string PasswordHash, string Salt) HashPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var salt = Convert.ToBase64String(hmac.Key); // Tạo salt từ khóa HMAC
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = hmac.ComputeHash(passwordBytes);
                var passwordHash = Convert.ToBase64String(hashBytes);

                return (passwordHash, salt);
            }
        }


        // Verifies the password
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt)))
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var computedHash = hmac.ComputeHash(passwordBytes);
                var computedHashString = Convert.ToBase64String(computedHash);
                return computedHashString == storedHash;
            }
        }
    }
}
