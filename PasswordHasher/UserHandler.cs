using System;

namespace PasswordHasher {

    public class UserHandler : IUserHandler {

        public IUser CreateUser(IInputHandler inputHandler) {

            IUser user = new User();

            user.Name = inputHandler.Prompt("Please input name of user you would like to create");
            user.Password = inputHandler.PromptPassword();

            PrintUser(user);

            if (inputHandler.PromptConfirm("Are you sure you want to add this user?") is false) {

                user.Name = " ajklhsgkldfhgklsdfjhgklsdfjhgusdfg";
                user.Password = "agsdgkndfkghdffghfdsgshdfg";
                user.Name = null;
                user.Password = null;
                user = null;

                return null;
            }
            
            return EncryptPassword(user);
        }
        
        
        public IUser EditUser(IInputHandler inputHandler, IUser user) {
        
            Console.WriteLine("1: Change user name");
            Console.WriteLine("2: Change password");
            var input = Console.ReadLine();

            switch(input) {

                case 1:

                    Console.Clear();
                    Console.WriteLine("Please input the name you would like to change to or leave blank to cancel");
                    var newName = Console.ReadLine();

                    user.Name = newName;

                    break;
                case 2:		

                    while (true) {

                        Console.Clear();
                        Console.WriteLine("Please input the new password");
                        var pass = Console.ReadLine();

                        if (pass.Length < 8) {

                            Console.WriteLine("Password has to be at least 8 characters");
                        }
                        else {

                            return EncryptPassword(user);
                            break;
                        }

                    }

                    break;				
            }
            
            return user;
        }
        
        private IUser EncryptPassword(IUser user) {
        
            IEncryptionHandler encrypter = new EncryptionHandler();
            user.Password = encrypter.EncryptPassword(user.Password);
            
            return user;
        }


        private void PrintUser(IUser user) {

            Console.WriteLine();
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Password: {user.Password}");

            Console.WriteLine();
        }

    }
}
