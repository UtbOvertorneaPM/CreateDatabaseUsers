using System;

namespace PasswordHasher {

    class Program {

        static void Main(string[] args) {

            var loop = true;

            IInputHandler inputHandler = new InputHandler();

            while (loop) {
                
                Console.WriteLine("1: Generate a password");
                Console.WriteLine("2: Create a new user in a MySql database");
                var choiceSelect = inputHandler.Prompt("Which option would you like?");
                Console.Clear();

                if (int.TryParse(choiceSelect, out int choiceResult)) {

                    switch (choiceResult) {

                        case 1:

                            GenerateSecurePassword(inputHandler);
                            break;

                        case 2:

                            CreateDbUser(inputHandler);
                            break;
                            
                        case 3:

                            EditDbUser(inputHandler);
                            break;


                        default:

                            Console.WriteLine("Not a valid input");
                            break;
                    }
                }
            }
        }


        public static void GenerateSecurePassword(IInputHandler inputHandler) {

            var password = inputHandler.PromptPassword();

            IEncryptionHandler encryptor = new EncryptionHandler();

            Console.WriteLine("Your encrypted password is:");
            Console.WriteLine(encryptor.EncryptPassword(password));
            Console.WriteLine();
        }


        public static void CreateDbUser(IInputHandler inputHandler) {


            IUserHandler handler = new UserHandler();
            IDbHandler dbHandler = new DbHandler();
            IValidator<IUser> validator = new UserValidator();

            dbHandler.Login(inputHandler);
            Console.Clear();

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
        
        public static void EditDbUser(IInputHandler inputHandler) {

	
            IUserHandler handler = new UserHandler();
            IDbHandler dbHandler = new DHandler();
            IValidator<IUser> validator = new UserValidator();

            dhHandler.Login(inputHandler);
            Console.Clear();

            while(true) {
                
                if(validator.Validate(user)) {
                    try {

                        var _ = dbHandler.EditUserAsync(user).Result;
                        Console.WriteLine("User Sucessfully edited");
                        Console.WriteLine();
                    }
                    catch (AggregateException) {

                        Console.WriteLine();
                        Console.WriteLine("Unable to connect to database");
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
