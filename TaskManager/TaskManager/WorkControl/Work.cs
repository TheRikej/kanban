using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.WorkControl
{
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

        public User? Creator { get; set; }
        public int CreatorId { get; set; }

        public List<User> Assignees { get; set; } = new();

    }
}
