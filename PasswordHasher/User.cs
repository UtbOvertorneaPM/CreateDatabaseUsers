using System.ComponentModel.DataAnnotations;

namespace PasswordHasher {

    public class User : IUser {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
