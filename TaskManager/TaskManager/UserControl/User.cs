using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UserControl
{
    public class User: ITaskAssignee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }
        public User? Supervisor { get; set; }

        public User(string name, string email, User? supervisor, string password)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Supervisor = supervisor;
            PasswordHash = HashPassword(password);
        }

        private static int HashPassword(string password)
        {
            return password.GetHashCode();
        }
    }
}
