using TaskManager.Database.Util;
using TaskManager.UserControl;

namespace TaskManager.WorkControl
{
    public partial class GroupCreation : Form
    {
        private readonly User _user;
        private List<User> _userList = new();
        public GroupCreation(User user)
        {
            _user = user;
            InitializeComponent();
            RenderMembers().ConfigureAwait(false);
        }

        private async Task RenderMembers()
        {
            _userList = await UserDatabase.GetUsersAsync();
            listMembers.Items.AddRange(_userList
                .Select(user => new ListViewItem(user.Name))
                .ToArray());
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Group Name");
                return;
            }

            List<User> members = new();

            foreach (var member in listMembers.CheckedItems.Cast<ListViewItem>())
            {
                members.Add(_userList[member.Index]);
            }

            if (!members.Where(a => a != null).Any())
            {
                MessageBox.Show("No Members Selected");
                return;
            }

            await GroupDatabase.CreateGroupAsync(tbName.Text, tbDescription.Text, _user, members);
            DestroyHandle();
        }
    }
}
