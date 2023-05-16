using System.Data;

using TaskManager.Database.Util;
using TaskManager.GroupControl;
using TaskManager.UserControl;

namespace TaskManager.WinForms
{
    public partial class UserEdit : Form
    {
        private readonly User _user;
        public UserEdit(User user)
        {
            _user = user;
            InitializeComponent();
            tbName.Text = user.Name;
            tbEmail.Text = user.Email;

        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Empty User Name");
                return;
            }

            if (tbEmail.Text == "")
            {
                MessageBox.Show("Empty Email");
                return;
            }

            if (tbPassword.Text != "" && !await UserDatabase.ChangePasswordAsync(_user.Id, tbPassword.Text))
            {
                MessageBox.Show("Failed to update User");
                return;
            }

            if (!await UserDatabase.EditUserAsync(_user.Id, tbName.Text, tbEmail.Text))
            {
                MessageBox.Show("Failed to update User");
                return;
            }
            DestroyHandle();
        }
    }
}
