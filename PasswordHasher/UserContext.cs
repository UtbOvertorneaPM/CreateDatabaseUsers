using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHasher {

    class UserContext : DbContext {

        private readonly string _password;
        private readonly string _database;
        private readonly string _user;
        private readonly string _port;

        public UserContext(string password, string database,  string user, string port = "3306") {

            _password = password;
            _database = database;
            _user = user;
            _port = port;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseMySQL($"Server=localhost;port={_port};Database={_database};user={_user};password={_password}");
        }
    }
}
