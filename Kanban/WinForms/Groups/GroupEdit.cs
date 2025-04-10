using System.Data;

using TaskManager.Database.Util;
using TaskManager.GroupControl;
using TaskManager.UserControl;

namespace TaskManager.WinForms
{
    public partial class GroupEdit : Form
    {
        private readonly bool _owner;
        private readonly Group _group;
        private List<User> _users = new();
        public GroupEdit(Group group, bool owner)
        {
            _group = group;
            _owner = owner;
            InitializeComponent();
            tbName.Text = _group.Name;
            tbDescription.Text = _group.Description;
            if (!owner)
            {
                EditButton.Visible = false;
            }

            RenderMembers().ConfigureAwait(false);
        }

        private async Task RenderMembers()
        {
            if (!_owner)
            {
                listMembers.CheckBoxes = false;
                listMembers.Items.AddRange(_group.Members
                    .Select(user => new ListViewItem(user.Name))
                    .ToArray());
            }
            else
            {
                _users = await UserDatabase.GetUsersAsync();

                listMembers.Items.AddRange(_users
                    .Select(user => new ListViewItem(user.Name))
                    .ToArray());

                foreach (var item in listMembers.Items.Cast<ListViewItem>())
                {
                    if (_group.Members
                        .FirstOrDefault(a => a.Id == _users[item.Index].Id) != null)
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Task Name");
                return;
            }

            List<User> members = new();

            foreach (var member in listMembers.CheckedItems.Cast<ListViewItem>())
            {
                members.Add(_users[member.Index]);
            }
            if (members.Count == 0)
            {
                MessageBox.Show("No Assignee Selected");
                return;
            }

            if (!await GroupDatabase.EditGroupAsync(_group.Id, tbName.Text, tbDescription.Text, members))
            {
                MessageBox.Show("Failed to update Group");
                return;
            }
            DestroyHandle();
        }
    }
}
