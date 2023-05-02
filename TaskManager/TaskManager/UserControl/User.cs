using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.WorkControl;

namespace TaskManager.UserControl
{
    public class User : ITaskAssignee
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }

        public User? Supervisor { get; set; }

        public List<Work> OwndedWorks { get; } = new();
        public List<Work> AssignedWorks { get; } = new();

        //[ForeignKey("Supervisor")]
        //public int SupervisorId { get; set; }

        public static int HashPassword(string password)
        {
            return password.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
