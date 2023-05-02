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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public User Creator { get; set; } = null;

        public List<User> Members { get; set; }

    }
}
