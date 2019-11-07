using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHasher {

    class UserContext : DbContext {

        private string _password;
        private string _database;
        private string _server;
        private string _user;
        private string _port;

        public UserContext(string password, string database, string server, string user, string port = "3306") {

            _password = password;
            _database = database;
            _server = server;
            _user = user;
            _port = port;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseMySQL($"Server={_server};port={_port};Database={_database};user={_user};password={_password}");
        }
    }
}
