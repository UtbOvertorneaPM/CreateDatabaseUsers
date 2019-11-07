using System;
using System.Security.Cryptography;

namespace PasswordHasher {

    class EncryptionHandler : IEncryptionHandler {

        public IUser Encrypt<T>(T user) where T : IUser {

            var saltSize = 32;
            var keySize = 512;

            using (var algorithm = new Rfc2898DeriveBytes(user.Password, saltSize, 1000, HashAlgorithmName.SHA512)) {

                var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                user.Password = $"{salt}.{key}";

                return user;
            }
        }
    }
}
