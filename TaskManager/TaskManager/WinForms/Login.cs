using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Database.Util;
using TaskManager.UserControl;

namespace TaskManager.WinForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (await UserDatabase.CheckPasswordAsync(tbEmail.Text, tbPassword.Text))
            {
                User user = await UserDatabase.GetUserByEmailAsync(tbEmail.Text);
                if (user == null) 
                { 
                    MessageBox.Show("Unkown Error");
                    return;
                }
                this.Hide();
                new WorkView(user).ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
    }
}
