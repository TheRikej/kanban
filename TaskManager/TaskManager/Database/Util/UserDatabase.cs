using System.Collections.ObjectModel;
using System.Data.Entity;
using TaskManager.UserControl;

namespace TaskManager.Database.Util
{
    public class UserDatabase
    {

        public static async Task<User> CreateUserAsync(string name, string email, string password)
        {
            using var db = new DbAccess();
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = User.HashPassword(password)
            };
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public static async Task<bool> CheckPasswordAsync(string email, string password)
        {
            using var db = new DbAccess();

            var user = db.Users.FirstOrDefault(user => user.Email == email);
            if (user == null) { return false; }
            return user.PasswordHash == User.HashPassword(password);
        }

        public static async Task<User> GetUserByEmailAsync(string email)
        {
            using var db = new DbAccess();

            return db.Users.FirstOrDefault(user => user.Email == email);
        }

        public static async Task<List<User>> GetUsers()
        {
            using var db = new DbAccess();

            return await db.Users.ToListAsync();
        }

        public static void UpdateUserName(Guid id, string name)
        {
            using var db = new DbAccess();

            db.Users.Find(id).Name = name;

        }
    }
}
