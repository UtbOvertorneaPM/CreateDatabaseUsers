namespace PasswordHasher {
    public interface IUserHandler {

        IUser CreateUser(IInputHandler inputHandler);
    }
}