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
using TaskManager.WorkControl;

namespace TaskManager.WinForms
{
    public partial class WorkEdit : Form
    {
        private Work _work;
        private List<User> _users;
        public WorkEdit(Work work)
        {
            _work = work;
            InitializeComponent();
            tbName.Text = _work.Name;
            tbDescription.Text = _work.Description;
            dateTimePicker.Value = _work.DueDate;
            cbPriority.SelectedIndex = _work.Priority - 1;
            cbStatus.SelectedIndex = (int)_work.Status;
            tbStatusNote.Text = _work.StatusMessage;

            _users = UserDatabase.GetUsers().Result;

            listAsignees.Items.AddRange(_users
                .Select((user, i) => new ListViewItem(user.Email, i))
                .ToArray());

            foreach (var item in listAsignees.Items.Cast<ListViewItem>())
            {
                if (_work.Assignees
                    .FirstOrDefault(a => a.Id == _users[item.ImageIndex].Id) != null)
                {
                    item.Checked = true;
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

            List<User> assignees = new();

            foreach (var assignee in listAsignees.CheckedItems.Cast<ListViewItem>())
            {
                assignees.Add(await UserDatabase.GetUserByEmailAsync(assignee.Text));
            }
            if (assignees.Count == 0)
            {
                MessageBox.Show("No Assignee Selected");
                return;
            }

            if (!await WorkDatabase.EditWorkAsync(_work.Id, tbName.Text, tbDescription.Text,
                dateTimePicker.Value.Date, cbPriority.SelectedIndex + 1,
                (WorkStatus)cbStatus.SelectedIndex, tbStatusNote.Text, assignees))
            {
                MessageBox.Show("Failed to update Task");
                return;
            }
            DestroyHandle();
        }
    }
}
