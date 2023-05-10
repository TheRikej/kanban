using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;

namespace TaskManager
{
    public partial class WorkView : Form
    {
        private readonly List<Group> _groups;
        private readonly User _user;
        public WorkView(User user)
        {
            _user = user;
            InitializeComponent();
            _groups = GroupDatabase.GetGroupsOfUser(_user);


            cbGroupFilter.Items.AddRange(_groups.Select(g => g.Name).ToArray());


            RenderWorks().ConfigureAwait(false);
            cbGroupFilter.SelectedIndex = 0;
            cbFilterStatus.SelectedIndex = 0;
            cbFilterPriority.SelectedIndex = 0;
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new WorkCreation(_user).ShowDialog();
            await RenderWorks();
        }

        private async Task RenderWorks()
        {
            dataGWWorks.DataSource = (await WorkDatabase.GetWorksOfUserAsync(_user))
                    .Where(work => (cbFilterStatus.SelectedIndex == 0)
                            || work.Status == (WorkStatus)(cbFilterStatus.SelectedIndex - 1))
                    .Where(work => work.Priority >= cbFilterPriority.SelectedIndex)
                    .Where(work => cbGroupFilter.SelectedIndex == 0 
                        || (cbGroupFilter.SelectedIndex == 1 && work.AssignedUsers.Select(u => u.Id).Contains(_user.Id))
                        || (cbGroupFilter.SelectedIndex >= 2 &&
                            work.AssignedGroups
                                .Select(g => g.Id)
                                .Contains(_groups[cbGroupFilter.SelectedIndex - 2].Id))
                        )
                    .OrderBy(work => (work.Status, -work.Priority, work.DueDate))
                    .ToList();

            dataGWWorks.Columns["Creator"].ValueType = typeof(string);
            dataGWWorks.Columns.Remove("CreatorId");
            dataGWWorks.Columns.Remove("Id");

            dataGWWorks.Update();
        }

        private async void DataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var work = (Work)dataGWWorks.CurrentRow.DataBoundItem;
            new WorkEdit(work, work.CreatorId == _user.Id).ShowDialog();
            await RenderWorks();
        }

        private async void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private async void CBFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new GroupView(_user).ShowDialog();
        }

        private async void CBGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }
    }
}