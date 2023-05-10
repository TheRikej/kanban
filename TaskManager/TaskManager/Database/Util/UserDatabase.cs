using Microsoft.EntityFrameworkCore;
using TaskManager.UserControl;

namespace TaskManager.Database.Util
{
    /// <summary>
    /// Class <c>UserDatabase</c> is responsible for all database queries concerning class <c>User</c>
    /// </summary>
    public class UserDatabase
    {
        /// <summary>
        /// Method <c>CreateUserAsync</c> creates a new user.
        /// <paramref name="name"> Is a name of a person </paramref> 
        /// <paramref name="email"> Is an email of a person </paramref>
        /// <paramref name="password"> Is a plaintext password of a person </paramref> 
        /// </summary>
        public static async Task<User> CreateUserAsync(string name, string email, string password)
        {
            using var db = new DbAccess();
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = User.HashPassword(password)
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Method <c>CheckPasswordAsync</c> checks whether password of a person is correct.
        /// <paramref name="email"> Is an email of a person </paramref>
        /// <paramref name="password"> Is a plaintext password of a person </paramref> 
        /// </summary>
        public static async Task<bool> CheckPasswordAsync(string email, string password)
        {
            using var db = new DbAccess();

            var user = await db.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user == null) { return false; }
            return user.PasswordHash == User.HashPassword(password);
        }

        /// <summary>
        /// Method <c>GetUserByEmailAsync</c> gets a person corresponding with the given email.
        /// <paramref name="email"> Is an email of a person </paramref>
        /// </summary>
        public static async Task<User?> GetUserByEmailAsync(string email)
        {
            using var db = new DbAccess();

            return await db.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        /// <summary>
        /// Method <c>GetUserByEmailAsync</c> gets all users.
        /// </summary>
        public static async Task<List<User>> GetUsersAsync()
        {
            using var db = new DbAccess();
            return await db.Users.ToListAsync();
        }
    }
}
