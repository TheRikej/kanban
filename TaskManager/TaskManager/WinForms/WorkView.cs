using System.Windows.Forms;
using TaskManager.Database;
using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.WorkControl;

namespace TaskManager
{
    public partial class WorkView : Form
    {
        private readonly User _user;
        public WorkView(User user)
        {
            _user = user;
            InitializeComponent();

            RenderWorks().Wait();
            dataGWWorks.Update();
            cbFilterStatus.SelectedIndex = 0;
            cbFilterPriority.SelectedIndex = 0;
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new WorkCreation(_user).ShowDialog();
            //await WorkDatabase.CreateWorkAsync("New Task", "Something", _user);//, new ITaskAssignee[] { });
            await RenderWorks();
        }

        private async Task RenderWorks()
        {
            dataGWWorks.DataSource = (await WorkDatabase.GetWorksOfUserAsync(_user))
                    .Where(work => (cbFilterStatus.SelectedIndex == 0) ? true : work.Status == (WorkStatus)(cbFilterStatus.SelectedIndex - 1))
                    .Where(work => work.Priority >= cbFilterPriority.SelectedIndex)
                    .OrderBy(work => (-work.Priority, work.DueDate))
                    .ToList();

            dataGWWorks.Columns["Creator"].ValueType = typeof(string);
            dataGWWorks.Columns.Remove("CreatorId");
            dataGWWorks.Columns.Remove("Id");

            dataGWWorks.Update();
        }

        private async void dataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new WorkEdit((Work)dataGWWorks.CurrentRow.DataBoundItem).ShowDialog();
            await RenderWorks();
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private async void cbFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }
    }
}