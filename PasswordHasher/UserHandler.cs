using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
