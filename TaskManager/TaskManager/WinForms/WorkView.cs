using TaskManager.Database;
using TaskManager.Database.Util;
using TaskManager.UserControl;
using TaskManager.WorkControl;

namespace TaskManager
{
    public partial class WorkView : Form
    {
        private readonly User _user;
        public WorkView(User user)
        {
            _user = user;
            InitializeComponent();

            RenderWorks();
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new WorkCreation(_user).ShowDialog();
            //await WorkDatabase.CreateWorkAsync("New Task", "Something", _user);//, new ITaskAssignee[] { });
            await RenderWorks();
        }

        private async Task RenderWorks()
        {
            listView1.Items.Clear();
            foreach (var work in await WorkDatabase.GetWorksOfUserAsync(_user))
            {
                //ListViewItem item = new ListViewItem();
                //item.SubItems.Add(work.Name);
                //item.SubItems.Add(work.Description);
                listView1.Items.Add(work.Name);
            }
        }

    }
}