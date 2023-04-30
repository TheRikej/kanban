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
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty Task Name");
                return;
            }
            await WorkDatabase.CreateWorkAsync(tbName.Text, tbDescription.Text, _user);
            DestroyHandle();
        }
    }
}
