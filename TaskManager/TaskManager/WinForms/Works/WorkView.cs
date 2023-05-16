using TaskManager.Database.Util;
using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.WinForms;
using TaskManager.GroupControl;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;

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
            if (_user.AdminRights)
            {
                userButton.Visible = true;
                userButton.Enabled = true;
            }

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
#pragma warning disable EF1001 // Internal EF Core API usage.
            SortableBindingList<Work> works = new((await WorkDatabase.GetWorksOfUserAsync(_user))
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
                    .ToList());
#pragma warning restore EF1001 // Internal EF Core API usage.
            dataGWWorks.DataSource = works;


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

        private void UserButton_Click(object sender, EventArgs e)
        {
            Dispose();
            new UserView(_user).ShowDialog();
        }

        private async void CBGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RenderWorks();
        }

        private void DataGWWorks_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    dataGWWorks.SortOrder == SortOrder.Descending)
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
                dataGWWorks.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
        }
    }
}