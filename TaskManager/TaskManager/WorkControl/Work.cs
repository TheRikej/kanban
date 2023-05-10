using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.GroupControl;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.WorkControl
{
    /// <summary>
    /// Class <c>Work</c> is a Database representation of a Task
    /// </summary>
    public class Work
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkStatus Status { get; set; } = WorkStatus.TODO;
        public string StatusMessage { get; set; } = "";

        public DateTime DueDate { get; set; }
        public int Priority { get; set; }

        public User Creator { get; set; }
        public int CreatorId { get; set; }

        public List<User> AssignedUsers { get; set; } = new();
        public List<Group> AssignedGroups { get; set; } = new();
    }
}
