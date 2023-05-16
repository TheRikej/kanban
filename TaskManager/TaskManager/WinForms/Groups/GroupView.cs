
using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace TaskManager
{
    public partial class GroupView : Form
    {
        private readonly User _user;
        public GroupView(User user)
        {
            _user = user;
            InitializeComponent();

            RenderGroups().ConfigureAwait(false);
            dataGWGroup.Update();
        }

        private async void NewTaskButton_Click(object sender, EventArgs e)
        {
            new GroupCreation(_user).ShowDialog();
            await RenderGroups();
        }

        private async Task RenderGroups()
        {
            dataGWGroup.DataSource = new SortableBindingList<Group>((await GroupDatabase.GetGroupsOfUserAsync(_user))
                    .ToList());

            dataGWGroup.Columns["Creator"].ValueType = typeof(string);
            dataGWGroup.Columns.Remove("CreatorId");

            dataGWGroup.Update();
        }

        private async void DataGWWorks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var group = (Group)dataGWGroup.CurrentRow.DataBoundItem;
            new GroupEdit(group, group.Creator.Id == _user.Id).ShowDialog();
            await RenderGroups();
        }

        private void WorkNavButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new WorkView(_user).ShowDialog();
        }

        private void DataGWWorks_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check which column is selected, otherwise set NewColumn to null.
            DataGridViewColumn newColumn = dataGWGroup.Columns[e.ColumnIndex];


            DataGridViewColumn oldColumn = dataGWGroup.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dataGWGroup.SortOrder == SortOrder.Descending)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Descending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Descending;
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
                dataGWGroup.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
        }
    }
}