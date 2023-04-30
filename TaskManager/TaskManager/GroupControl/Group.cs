using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Description { get; set; }

        [NotMapped]
        public User Creator { get; set; }

        [NotMapped]
        public List<User> Members { get; set; }

        public Group(string name, string description, User creator, List<User> members)
        {
            Id = new Guid();
            Description = description;
            Name = name;
            Creator = creator;
            Members = members;
        }

    }
}
