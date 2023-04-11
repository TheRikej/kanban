using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.UserControl;

namespace TaskManager.GroupControl
{
    public class Group: ITaskAssignee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Creator { get; set; }

        public User[] Members { get; set; }

        public Group(string name, User creator, User[] members)
        {
            Id = new Guid();
            Name = name;
            Creator = creator;
            Members = members;
        }

    }
}
