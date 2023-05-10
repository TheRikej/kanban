
using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;

namespace TaskManager
{
    public partial class GroupView : Form
    {
        private readonly User _user;
        public GroupView(User user)
        {
            _user = user;
            InitializeComponent();

            RenderGroups().ConfigureAwait(false);
            dataGWWorks.Update();
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new GroupCreation(_user).ShowDialog();
            await RenderGroups();
        }

        private async Task RenderGroups()
        {
            dataGWWorks.DataSource = (await GroupDatabase.GetGroupsOfUserAsync(_user))
                    .ToList();

            dataGWWorks.Columns["Creator"].ValueType = typeof(string);
            dataGWWorks.Columns.Remove("CreatorId");

            dataGWWorks.Update();
        }

        private async void DataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var group = (Group)dataGWWorks.CurrentRow.DataBoundItem;
            new GroupEdit(group, group.Creator.Id == _user.Id).ShowDialog();
            await RenderGroups();
        }

        private async void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderGroups();
        }

        private async void CBFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderGroups();
        }

        private void WorkNavButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new WorkView(_user).ShowDialog();
        }
    }
}