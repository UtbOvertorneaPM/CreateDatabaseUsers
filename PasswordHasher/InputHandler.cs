using System;

namespace PasswordHasher {

    public class InputHandler : IInputHandler {


        public string Prompt(string msg) {

            Console.WriteLine(msg);

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) {

                Console.WriteLine();

                return Prompt(msg);
            }

            return input;
        }


        public string PromptPassword() {

            Console.WriteLine("Please input password, and press enter to confirm");
            var input = "";

            while (true) {

                var keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.Enter)
                    break;

                input += keyPressed.KeyChar;
            }

            if (string.IsNullOrWhiteSpace(input) is true) {

                Console.WriteLine("Please input a valid password");
                Console.WriteLine();

                input = PromptPassword();
            }

            return input;
        }


        public bool PromptConfirm(string msg) {

            Console.WriteLine(msg);
            var input = Prompt("Please confirm Y/N");

            if (string.IsNullOrWhiteSpace(input)) {

                Console.WriteLine("Please input either Y or N!");
                Console.WriteLine();

                return PromptConfirm(msg);
            }

            return input.ToLower() == "n" ? false : true;
        }
    }
}
