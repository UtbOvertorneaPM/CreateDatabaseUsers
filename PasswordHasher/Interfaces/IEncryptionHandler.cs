namespace PasswordHasher {
    interface IEncryptionHandler {
        string EncryptPassword(string password);
    }
}