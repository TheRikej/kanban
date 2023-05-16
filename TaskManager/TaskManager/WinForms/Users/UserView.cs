
using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;

namespace TaskManager
{
    public partial class UserView : Form
    {
        private readonly User _user;
        public UserView(User user)
        {
            _user = user;
            InitializeComponent();

            RenderUsers().ConfigureAwait(false);
            dataGWWorks.Update();
        }

        private async void NewUserButton_Click(object sender, EventArgs e)
        {
            new UserCreation().ShowDialog();
            await RenderUsers();
        }

        private async Task RenderUsers()
        {
            dataGWWorks.DataSource = (await UserDatabase.GetUsersAsync())
                .OrderBy(user => user.Name)
                .ToList();

            dataGWWorks.Columns.Remove("PasswordHash");
            dataGWWorks.Columns.Remove("AdminRights");

            dataGWWorks.Update();
        }

        private async void DataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = (User)dataGWWorks.CurrentRow.DataBoundItem;
            new UserEdit(user).ShowDialog();
            await RenderUsers();
        }

        private void WorkNavButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new WorkView(_user).ShowDialog();
        }
    }
}