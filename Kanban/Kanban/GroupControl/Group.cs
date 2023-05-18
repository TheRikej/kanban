using System.Data.Entity.Infrastructure;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.GroupControl
{
    /// <summary>
    /// Class <c>Group</c> is a Database representation of a Group
    /// </summary>
    public class Group

    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public User Creator { get; set; } = new();
        public int CreatorId { get; set; }

        public List<User> Members { get; set; } = new();

        public List<Work> AssignedWorks { get; set; } = new();

    }
}
