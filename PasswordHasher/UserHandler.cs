using System;

namespace PasswordHasher {

	
       
	
	
    public class UserHandler : IUserHandler {
	    
	 public static void CreateDbUser(IInputHandler inputHandler) {

            IDbHandler dbHandler = new DbHandler();
            IValidator<IUser> validator = new UserValidator();

            dbHandler.Login(inputHandler);
            Console.Clear();

            while (true) {

                var user = CreateUser(inputHandler);

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
        

        
        
        public static void EditDbUser(IInputHandler inputHandler) {

            IDbHandler dbHandler = new DHandler();
            IValidator<IUser> validator = new UserValidator();

            dhHandler.Login(inputHandler);
            Console.Clear();

	    dbHandler.DisplayUsersAsync();	
            
            while(true) {
                
                Console.WriteLine("Please enter the ID of the user you wish to edit or leave blank to return");
                var id = Console.ReadLine();

                if (string.NullOrEmpty(id)) {

                    return;
                }

                var user = dbHandler.GetUser(id);
                user = EditUser(inputHandler, user);

		if(user != null && validator.Validate(user)) {

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
            }
        }          

        
        public IUser EditUser(IInputHandler inputHandler, IUser user) {
        
            Console.WriteLine("1: Change user name");
            Console.WriteLine("2: Change password");
            var input = Console.ReadLine();

            switch(input) {

                case 1:

                    Console.Clear();
	            user.Name = inputHandler.Prompt("Please input the new name or leave blank to cancel");
                    break;
			    
                case 2:		

                    while (true) {

                        Console.Clear();
			user.Password = inputHandler.PromptPassword();

                        if (user.Password.Length < 8) {

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
