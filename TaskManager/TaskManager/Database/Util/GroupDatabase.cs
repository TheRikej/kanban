using TaskManager.UserControl;
using TaskManager.GroupControl;
using Microsoft.EntityFrameworkCore;
using TaskManager.WorkControl;

namespace TaskManager.Database.Util
{
    public class GroupDatabase
    {
        public static async Task<List<Group>> GetGroupsOfUserAsync(User user)
        {
            using var db = new DbAccess();

            return await db.Groups
                .Where(group => user.AdminRights || group.Members.Contains(user) || group.Creator == user)
                .Include(g => g.Members)
                .Include(g => g.Creator)
                .ToListAsync();
        }

        public static List<Group> GetGroupsOfUser(User user)
        {
            using var db = new DbAccess();

            return db.Groups
                .Where(group => user.AdminRights || group.Members.Contains(user) || group.Creator == user)
                .Include(g => g.Members)
                .Include(g => g.Creator)
                .ToList();
        }

        public static async Task<List<Group>> GetGroupsAsync()
        {
            using var db = new DbAccess();

            return await db.Groups
                .ToListAsync();
        }

        public static async Task CreateGroupAsync(string name, string description, User creator, List<User> members)
        {
            using var db = new DbAccess();


            db.AttachRange(members);

            var group = new Group
            {
                Name = name,
                Description = description,
                CreatorId = creator.Id,
                Members = members
            };

            db.Groups.Add(group);

            await db.SaveChangesAsync();
        }

        public static async Task<bool> EditGroupAsync(int id, string name, string description, List<User> members)
        {
            using var db = new DbAccess();
            db.AttachRange(members);

            var group = await db.Groups
                .Include(group => group.Members)
                .SingleOrDefaultAsync(work => work.Id == id);

            if (group != null)
            {
                db.Groups.Attach(group);
                group.Name = name;
                group.Description = description;

                group.Members = members;

                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
