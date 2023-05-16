
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using TaskManager.GroupControl;
using TaskManager.WorkControl;

namespace TaskManager.UserControl
{
    /// <summary>
    /// Class <c>User</c> is a Database representation of a User
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool AdminRights { get; set; }

        public List<Group> GroupsMember { get; set; } = new();
        public List<Work> OwnedWorks { get; } = new();
        public List<Group> OwnedGroups { get; } = new();
        public List<Work> AssignedWorks { get; } = new();



        public static string HashPassword(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString());
            }
            return builder.ToString();

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
