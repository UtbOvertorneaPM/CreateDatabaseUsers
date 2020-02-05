using System;

namespace PasswordHasher {

    class Program {

        static void Main(string[] args) {

            var loop = true;

            IInputHandler inputHandler = new InputHandler();

            while (loop) {
                
                Console.WriteLine("1: Generate a password");
                Console.WriteLine("2: Create a new user in a MySql database");
		Console.WriteLine("3: Edit existing user");
		    
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


    }
}
