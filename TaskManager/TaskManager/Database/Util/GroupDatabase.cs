using TaskManager.UserControl;
using TaskManager.GroupControl;
using System.Data.Entity;

namespace TaskManager.Database.Util
{
    public class GroupDatabase
    {

        public async Task<List<Group>> GetGroupsOfUserAsync(User user)
        {
            using var db = new DbAccess();

            return await db.Groups
                .Where(group => group.Members.Contains(user) || group.Creator == user)
                .ToListAsync();
        }

        public async Task CreateGroupAsync(string name, string description, User creator, List<User> members)
        {
            using var db = new DbAccess();

            var group =  new Group(){ 
                Name = name,
                Description = description,
                Creator = creator,
                Members = members
            };
        }
    }
}
