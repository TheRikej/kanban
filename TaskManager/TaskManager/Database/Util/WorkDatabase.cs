using Microsoft.EntityFrameworkCore;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.GroupControl;

namespace TaskManager.Database.Util
{
    /// <summary>
    /// Class <c>WorkDatabase</c> is responsible for all database queries concerning class <c>Work</c>
    /// </summary>
    public class WorkDatabase
    {
        /// <summary>
        /// Method <c>GetWorksOfUserAsync</c> gets all <c>Work</c> of a <c>User</c>. 
        /// <paramref name="user"> Is a <c>User</c> whose <c>Work</c>s you want to get</paramref>
        /// </summary>
        public static async Task<List<Work>> GetWorksOfUserAsync(User user)
        {
            using var db = new DbAccess();

            return await db.Works
                .Where(work => work.Creator == user || work.AssignedUsers.Contains(user))
                .Include(a => a.AssignedUsers)
                .Include(g => g.AssignedGroups)
                .ToListAsync();
        }

        /// <summary>
        /// Method <c>CreateWorkAsync</c> creates a new <c>Work</c>. 
        /// <paramref name="name"> Is a name of a <c>Work</c> </paramref>
        /// <paramref name="description"> Is a description of a <c>Work</c> </paramref>
        /// <paramref name="creator"> Is a creator of a <c>Work</c> </paramref>
        /// <paramref name="date"> Is a Due Date of a <c>Work</c> </paramref>
        /// <paramref name="priority"> Is a priority of a <c>Work</c> </paramref>
        /// <paramref name="assignees"> Is a list of assigned <c>User</c>s of a <c>Work</c> </paramref>
        /// <paramref name="groups"> Is a list of assigned <c>Group</c>s of a <c>Work</c> </paramref>
        /// </summary>
        public static async Task CreateWorkAsync(string name, string description, User creator,
            DateTime date, int priority, List<User> assignees, List<Group> groups)
        {
            using var db = new DbAccess();

            db.AttachRange(assignees);
            db.AttachRange(groups);

            var work = new Work
            {
                Name = name,
                Description = description,
                CreatorId = creator.Id,
                DueDate = date,
                Priority = priority,
                AssignedUsers = assignees,
                AssignedGroups = groups
            };

            db.Works.Add(work);

            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Method <c>EditWorkAsync</c> creates a new <c>Work</c>. 
        /// <paramref name="name"> Is a name of a <c>Work</c> </paramref>
        /// <paramref name="description"> Is a description of a <c>Work</c> </paramref>
        /// <paramref name="date"> Is a Due Date of a <c>Work</c> </paramref>
        /// <paramref name="priority"> Is a priority of a <c>Work</c> </paramref>
        /// <paramref name="status"> Is a Status of a <c>Work</c> </paramref>
        /// <paramref name="statusNote"> Is a Status Message of a <c>Work</c> </paramref>
        /// <paramref name="assignees"> Is a list of assigned <c>User</c>s of a <c>Work</c> </paramref>
        /// <paramref name="groups"> Is a list of assigned <c>Group</c>s of a <c>Work</c> </paramref>
        /// </summary>
        public static async Task<bool> EditWorkAsync(int id, string name, string description,
                DateTime date, int priority, WorkStatus status, string statusNote, List<User> assignees, List<Group> groups)
        {
            using var db = new DbAccess();
            db.AttachRange(assignees);
            db.AttachRange(groups);

            var work = await db.Works
                .Include(work => work.AssignedUsers)
                .Include(work => work.AssignedGroups)
                .SingleOrDefaultAsync(work => work.Id == id);

            if (work != null)
            {
                db.Works.Attach(work);
                work.Name = name;
                work.Description = description;
                work.DueDate = date;
                work.Priority = priority;
                work.Status = status;
                work.StatusMessage = statusNote;
                work.AssignedUsers = assignees;
                work.AssignedGroups = groups;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static async Task<bool> EditWorkStatusAsync(int id, WorkStatus status, string statusMessage)
        {
            using var db = new DbAccess();

            var work = await db.Works.SingleOrDefaultAsync(work => work.Id == id);
            if (work != null)
            {
                work.Status = status;
                work.StatusMessage = statusMessage;
                await db.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
