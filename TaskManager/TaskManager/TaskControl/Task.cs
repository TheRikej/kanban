using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.UserControl;


namespace TaskManager.TaskControl
{
    public class AssignedTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public User Creator { get; set; }
        public ITaskAssignee[] Assignees { get; set; }

        public AssignedTask(string name, string description, User creator, ITaskAssignee[] assignees) 
        {
            Name = name;
            Description = description;
            Creator = creator;
            Assignees = assignees;
            Status = "TODO";
            Note = "";
        }
    }
}
