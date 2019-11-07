using MySql.Data.MySqlClient;
using System;
using System.Net.Sockets;

namespace PasswordHasher {

    class Program {

        static void Main(string[] args) {

            IInputHandler inputHandler = new InputHandler();
            IUserHandler handler = new UserHandler();
            IDbHandler dbHandler = new DbHandler();
            IValidator<IUser> validator = new UserValidator();

            dbHandler.Login(inputHandler);
            Console.WriteLine();

            while (true) {

                var user = handler.CreateUser(inputHandler);

                if (validator.Validate(user)) {

                    try {

                        var _ = dbHandler.AddUserAsync(user).Result;
                        Console.WriteLine("User successfully added");
                        Console.WriteLine();
                    }
                    catch (AggregateException) {

                        Console.WriteLine();
                        Console.WriteLine("Unable to connect to database");
                    }
                }
                else {

                    Console.WriteLine("User input invalid");
                }

                if (inputHandler.PromptConfirm("Do you wish to add more users?") is false) {
                    break;
                }
            }
        }

    }
}
