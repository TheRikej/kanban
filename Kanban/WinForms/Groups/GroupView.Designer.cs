namespace TaskManager
{
    partial class GroupView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGWGroup = new DataGridView();
            WorkNavButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGWGroup).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(70, 29);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "New Group";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewTaskButton_Click;
            // 
            // dataGWWorks
            // 
            dataGWGroup.AllowUserToAddRows = false;
            dataGWGroup.AllowUserToDeleteRows = false;
            dataGWGroup.AllowUserToResizeRows = false;
            dataGWGroup.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGWGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGWGroup.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGWGroup.Location = new Point(70, 82);
            dataGWGroup.Name = "dataGWWorks";
            dataGWGroup.ReadOnly = true;
            dataGWGroup.RowHeadersWidth = 51;
            dataGWGroup.RowTemplate.Height = 29;
            dataGWGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGWGroup.Size = new Size(674, 321);
            dataGWGroup.TabIndex = 3;
            dataGWGroup.CellDoubleClick += DataGWWorks_CellDoubleClick;
            // 
            // WorkNavButton
            // 
            WorkNavButton.Location = new Point(650, 438);
            WorkNavButton.Name = "WorkNavButton";
            WorkNavButton.Size = new Size(94, 29);
            WorkNavButton.TabIndex = 4;
            WorkNavButton.Text = "Tasks";
            WorkNavButton.UseVisualStyleBackColor = true;
            WorkNavButton.Click += WorkNavButton_Click;
            // 
            // GroupView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 479);
            Controls.Add(WorkNavButton);
            Controls.Add(dataGWGroup);
            Controls.Add(button1);
            Name = "GroupView";
            Text = "Group Navigation";
            ((System.ComponentModel.ISupportInitialize)dataGWGroup).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dataGWGroup;
        private Button WorkNavButton;
    }
}