namespace PasswordHasher {
    interface IEncryptionHandler {
        IUser Encrypt<T>(T user) where T : IUser;
    }
}