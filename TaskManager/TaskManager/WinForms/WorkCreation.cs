using TaskManager.Database.Util;
using TaskManager.UserControl;

namespace TaskManager.WorkControl
{
    public partial class WorkCreation : Form
    {
        private readonly User _user;
        public WorkCreation(User user)
        {
            _user = user;
            InitializeComponent();
            //TODO not async enough
            listAsignees.Items.AddRange(UserDatabase.GetUsers().Result
                .Select(user => new ListViewItem(user.Email))
                .ToArray());
            cbPriority.SelectedIndex = 0;
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Task Name");
                return;
            }

            List<User> assignees = new();

            foreach (var assignee in listAsignees.CheckedItems.Cast<ListViewItem>())
            {
                assignees.Add(await UserDatabase.GetUserByEmailAsync(assignee.Text));
            }

            if (assignees.Where(a=> a != null).Count() == 0)
            {
                MessageBox.Show("No Assignee Selected");
                return;
            }

            await WorkDatabase.CreateWorkAsync(tbName.Text, tbDescription.Text, _user,
                dateTimePicker.Value.Date, cbPriority.SelectedIndex + 1, assignees);
            DestroyHandle();
        }

    }
}
