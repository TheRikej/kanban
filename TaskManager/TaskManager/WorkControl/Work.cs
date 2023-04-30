using System.ComponentModel.DataAnnotations;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.TaskControl
{
    public class Work
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkStatus Status { get; set; }
        public string StatusMessage { get; set; }

        public User Creator { get; set; }
        public int CreatorId { get; set; }
        //public ITaskAssignee[] Assignees { get; set; }

        public Work()
        {

            Status = WorkStatus.TODO;
            StatusMessage = "";
        }
    }
}
