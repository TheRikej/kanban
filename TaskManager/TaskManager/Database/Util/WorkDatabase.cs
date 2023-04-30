using Microsoft.EntityFrameworkCore;

using TaskManager.TaskControl;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.Database.Util
{
    public class WorkDatabase
    {

        public static async Task<List<Work>> GetWorksOfUserAsync(User user)
        {
            using var db = new DbAccess();

            return await db.Works
                //.Where(work => work.Creator == user)// || work.Assignees.Contains(user))
                .ToListAsync();
        }

        public static async Task CreateWorkAsync(string name, string description, User creator)
        {
            using var db = new DbAccess();

            db.Works.Add(new Work { Name = name, Description = description, CreatorId = creator.Id});
            await db.SaveChangesAsync();

        }

        //public async Task EditWorkStatusAsync(int id, WorkStatus status, string statusMessage)
        //{
        //    using var db = new DbAccess();

        //    var work = await db.Works.SingleOrDefaultAsync(work => work.Id == id);
        //    if (work != null) 
        //    {
        //        work.Status = status;
        //        work.StatusMessage = statusMessage;
        //        await db.SaveChangesAsync();
        //    }

        //}
    }
}
