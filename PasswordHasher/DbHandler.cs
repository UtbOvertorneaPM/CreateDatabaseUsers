using System.Threading.Tasks;

namespace PasswordHasher {


    public class DbHandler : IDbHandler {

        private UserContext _userContext;

        public void Login(IInputHandler inputHandler) {

            var database = inputHandler.Prompt("Input the database name");
            var user = inputHandler.Prompt("Input database user name");
            var password = inputHandler.PromptPassword();
            
            _userContext = new UserContext(password, database, user);
        }

        public async Task<int> AddUserAsync(IUser user) {
            
            await _userContext.Users.AddAsync((User)user);
            return await _userContext.SaveChangesAsync();
        }
        
        public async Task DisplayUsersAsync() {
         
            var users = await _userContxt.Users.ToListAsync();
            DisplayUsers(users);
        }
        
        
        private void DisplayUsers(List<IUser> users) {
        
            for(i = 0; i < users.count; i++) {
            
                Console.WriteLine($"{i} : {users.Name}");
            }
        }

        ~DbHandler() {
            
            _userContext.Dispose();
        }
    }
}
