using System;
using System.Security.Cryptography;

namespace PasswordHasher {

    class EncryptionHandler : IEncryptionHandler {

        public string EncryptPassword(string password) {

            var saltSize = 32;
            var keySize = 512;

            using (var algorithm = new Rfc2898DeriveBytes(password, saltSize, 12000, HashAlgorithmName.SHA512)) {

                var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                password = $"{salt}.{key}";

                return password;
            }
        }
    }
}
