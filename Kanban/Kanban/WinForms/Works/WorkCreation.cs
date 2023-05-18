using TaskManager.Database.Util;
using TaskManager.GroupControl;
using TaskManager.UserControl;

namespace TaskManager.WorkControl
{
    public partial class WorkCreation : Form
    {
        private readonly User _user;
        private List<User> _userList = new();
        private List<Group> _groupList = new();
        public WorkCreation(User user)
        {
            _user = user;
            InitializeComponent();
            RenderAssignees().ConfigureAwait(false);

            cbPriority.SelectedIndex = 0;
        }

        private async Task RenderAssignees()
        {
            _userList = await UserDatabase.GetUsersAsync();
            listAssignees.Items.AddRange(_userList
                .Select(user => new ListViewItem(user.Name))
                .ToArray());

            _groupList = await GroupDatabase.GetGroupsAsync();
            listAssignedGroups.Items.AddRange(_groupList
                .Select(group => new ListViewItem(group.Name))
                .ToArray());
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Task Name");
                return;
            }

            List<User> assignedUsers = new();
            List<Group> assignedGroup = new();

            foreach (var assignee in listAssignees.CheckedItems.Cast<ListViewItem>())
            {
                assignedUsers.Add(_userList[assignee.Index]);
            }

            foreach (var assignee in listAssignedGroups.CheckedItems.Cast<ListViewItem>())
            {
                assignedGroup.Add(_groupList[assignee.Index]);
            }

            if (!assignedUsers.Any() && !assignedGroup.Any())
            {
                MessageBox.Show("No Assignee Selected");
                return;
            }

            await WorkDatabase.CreateWorkAsync(tbName.Text, tbDescription.Text, _user,
                dateTimePicker.Value.Date, cbPriority.SelectedIndex + 1, assignedUsers, assignedGroup);
            DestroyHandle();
        }
    }
}