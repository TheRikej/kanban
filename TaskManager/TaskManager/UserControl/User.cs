using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.TaskControl;

namespace TaskManager.UserControl
{
    public class User : ITaskAssignee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }

        public User? Supervisor { get; set; }

        [ForeignKey("CreatorId")]
        public List<Work> OwndedWorks { get; set; } = new();
        //[ForeignKey("Supervisor")]
        //public int SupervisorId { get; set; }

        public static int HashPassword(string password)
        {
            return password.GetHashCode();
        }
    }
}
