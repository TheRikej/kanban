using TaskManager.Database.Util;
using TaskManager.UserControl;

namespace TaskManager.WorkControl
{
    public partial class UserCreation : Form
    {
        public UserCreation()
        {
            InitializeComponent();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
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

            if (tbPassword.Text == "")
            {
                MessageBox.Show("Empty Password");
                return;
            }


            await UserDatabase.CreateUserAsync(tbName.Text, tbEmail.Text, tbPassword.Text);
            DestroyHandle();
        }

    }
}
