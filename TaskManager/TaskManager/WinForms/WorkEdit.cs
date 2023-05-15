
using System.Data;

using TaskManager.Database.Util;
using TaskManager.GroupControl;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager.WinForms
{
    public partial class WorkEdit : Form
    {
        private readonly Work _work;
        private List<User> _users;
        private List<Group> _groups;
        private bool _owner;
        public WorkEdit(Work work, bool owner)
        {
            _owner = owner;
            _users = new();
            _work = work;
            InitializeComponent();
            tbName.Text = _work.Name;
            tbDescription.Text = _work.Description;
            dateTimePicker.Value = _work.DueDate;
            cbPriority.SelectedIndex = _work.Priority - 1;
            cbStatus.SelectedIndex = (int)_work.Status;
            tbStatusNote.Text = _work.StatusMessage;

            if (!owner)
            {
                tbName.Enabled = false;
                tbDescription.Enabled = false;
                dateTimePicker.Enabled = false;
                cbPriority.Enabled = false;
            }

            RenderAssignees().ConfigureAwait(false);
        }

        private async Task RenderAssignees()
        {
            if (!_owner)
            {
                listAssignees.Items.AddRange(_work.AssignedUsers
                    .Select(user => new ListViewItem(user.Name))
                    .ToArray());
                listAssignees.CheckBoxes = false;

                listGroups.Items.AddRange(_work.AssignedGroups
                    .Select(group => new ListViewItem(group.Name))
                    .ToArray());
                listGroups.CheckBoxes = false;
            }
            else
            {
                _users = await UserDatabase.GetUsersAsync();

                listAssignees.Items.AddRange(_users
                    .Select(user => new ListViewItem(user.Name))
                    .ToArray());

                foreach (var item in listAssignees.Items.Cast<ListViewItem>())
                {
                    if (_work.AssignedUsers
                        .FirstOrDefault(a => a.Id == _users[item.Index].Id) != null)
                    {
                        item.Checked = true;
                    }
                }

                _groups = await GroupDatabase.GetGroupsAsync();

                listGroups.Items.AddRange(_groups
                    .Select(group => new ListViewItem(group.Name))
                    .ToArray());

                foreach (var item in listGroups.Items.Cast<ListViewItem>())
                {
                    if (_work.AssignedGroups
                        .FirstOrDefault(a => a.Id == _groups[item.Index].Id) != null)
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (!_owner)
            {
                if (!await WorkDatabase.EditWorkStatusAsync(_work.Id,
                (WorkStatus)cbStatus.SelectedIndex, tbStatusNote.Text))
                {
                    MessageBox.Show("Failed to update Task");
                    return;
                }
                DestroyHandle();
                return;
            }

            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Task Name");
                return;
            }

            List<User> assignedUsers = new();
            List<Group> assignedGroups = new();

            foreach (var assignee in listAssignees.CheckedItems.Cast<ListViewItem>())
            {
                assignedUsers.Add(_users[assignee.Index]);
            }


            foreach (var assignee in listGroups.CheckedItems.Cast<ListViewItem>())
            {
                assignedGroups.Add(_groups[assignee.Index]);
            }

            if (!assignedUsers.Any() && !assignedGroups.Any())
            {
                MessageBox.Show("No Assignee Selected");
                return;
            }

            if (!await WorkDatabase.EditWorkAsync(_work.Id, tbName.Text, tbDescription.Text,
                dateTimePicker.Value.Date, cbPriority.SelectedIndex + 1,
                (WorkStatus)cbStatus.SelectedIndex, tbStatusNote.Text, assignedUsers, assignedGroups))
            {
                MessageBox.Show("Failed to update Task");
                return;
            }
            DestroyHandle();
        }
    }
}
