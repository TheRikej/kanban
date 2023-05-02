using Microsoft.EntityFrameworkCore;

using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WorkControl;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManager.Database.Util
{
    public class WorkDatabase
    {

        public static async Task<List<Work>> GetWorksOfUserAsync(User user)
        {
            using var db = new DbAccess();

            return db.Works
                .Where(work => work.Creator == user || work.Assignees.Contains(user))
                .Include(a => a.Assignees)
                .ToList();
        }

        public static async Task CreateWorkAsync(string name, string description, User creator,
            DateTime date, int priority, List<User> assignees)
        {
            using var db = new DbAccess();

            var user = db.Entry(assignees[0]);

            var work = new Work
            {
                Name = name,
                Description = description,
                CreatorId = creator.Id,
                DueDate = date,
                Priority = priority,
                Assignees = new()
            };
            db.AttachRange(assignees);
            work.Assignees.AddRange(assignees.Where(x => x != null));
            //work.Assignees.Add(user.Entity);


            db.Works.Add(work);
            //db.Entry(work).State = EntityState.Added;


            await db.SaveChangesAsync();
        }

        public static async Task<bool> EditWorkAsync(int id, string name, string description,
                DateTime date, int priority, WorkStatus status, string statusNote, List<User> assignees)
        {
            using var db = new DbAccess();
            db.AttachRange(assignees);

            var work = await db.Works
                .Include(work => work.Assignees)
                .SingleOrDefaultAsync(work => work.Id == id);

            if (work != null)
            {
                db.Works.Attach(work);
                db.Works.Include("Assignees");
                work.Name = name;
                work.Description = description;
                work.DueDate = date;
                work.Priority = priority;
                work.Status = status;
                work.StatusMessage = statusNote;
                work.Assignees.RemoveAll(a => true);
                work.Assignees = assignees;

                //db.SaveChanges();
                //work.Assignees.AddRange(assignees);

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static async Task EditWorkStatusAsync(int id, WorkStatus status, string statusMessage)
        {
            using var db = new DbAccess();

            var work = await db.Works.SingleOrDefaultAsync(work => work.Id == id);
            if (work != null)
            {
                work.Status = status;
                work.StatusMessage = statusMessage;
                await db.SaveChangesAsync();
            }

        }
    }
}
