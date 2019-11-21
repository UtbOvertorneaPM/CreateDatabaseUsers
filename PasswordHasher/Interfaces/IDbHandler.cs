using System.Threading.Tasks;

namespace PasswordHasher {
    public interface IDbHandler {
        Task<int> AddUserAsync(IUser user);
        void Login(IInputHandler inputHandler);
    }
}