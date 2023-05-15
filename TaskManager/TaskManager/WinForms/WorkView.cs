using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TaskManager
{
    public partial class WorkView : Form
    {
        private readonly List<Group> _groups;
        private readonly User _user;
        public WorkView(User user)
        {
            _user = user;
            InitializeComponent();
            _groups = GroupDatabase.GetGroupsOfUser(_user);


            cbGroupFilter.Items.AddRange(_groups.Select(g => g.Name).ToArray());

            Task.Run(RenderWorks);
            RenderWorks().ConfigureAwait(false);
            cbGroupFilter.SelectedIndex = 0;
            cbFilterStatus.SelectedIndex = 0;
            cbFilterPriority.SelectedIndex = 0;
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new WorkCreation(_user).ShowDialog();
            await RenderWorks();
        }

        private async Task RenderWorks()
        {
            //DataView dv = new DataView();
            //dv.

            dataGWWorks.DataSource = (await WorkDatabase.GetWorksOfUserAsync(_user))
                    .Where(work => (cbFilterStatus.SelectedIndex == 0)
                            || work.Status == (WorkStatus)(cbFilterStatus.SelectedIndex - 1))
                    .Where(work => work.Priority >= cbFilterPriority.SelectedIndex)
                    .Where(work => cbGroupFilter.SelectedIndex == 0
                        || (cbGroupFilter.SelectedIndex == 1 && work.AssignedUsers.Select(u => u.Id).Contains(_user.Id))
                        || (cbGroupFilter.SelectedIndex >= 2 &&
                            work.AssignedGroups
                                .Select(g => g.Id)
                                .Contains(_groups[cbGroupFilter.SelectedIndex - 2].Id))
                        )
                    .OrderBy(work => (work.Status, -work.Priority, work.DueDate))
                    .ToList();

            dataGWWorks.Columns["Creator"].ValueType = typeof(string);
            dataGWWorks.Columns.Remove("CreatorId");
            dataGWWorks.Columns.Remove("Id");

            dataGWWorks.Update();
        }

        private async void DataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var work = (Work)dataGWWorks.CurrentRow.DataBoundItem;
            new WorkEdit(work, work.CreatorId == _user.Id).ShowDialog();
            await RenderWorks();
        }

        private async void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private async void CBFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new GroupView(_user).ShowDialog();
        }

        private async void CBGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private void dataGWWorks_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check which column is selected, otherwise set NewColumn to null.
            DataGridViewColumn newColumn = dataGWWorks.Columns[e.ColumnIndex];


            DataGridViewColumn oldColumn = dataGWWorks.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dataGWWorks.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // If no column has been selected, display an error dialog  box.
            if (newColumn == null)
            {
                MessageBox.Show("Select a single column and try again.",
                    "Error: Invalid Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                dataGWWorks.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
        }
    }
}