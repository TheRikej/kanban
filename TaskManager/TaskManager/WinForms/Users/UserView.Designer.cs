namespace TaskManager
{
    partial class UserView
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
            dataGWWorks = new DataGridView();
            WorkNavButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGWWorks).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(70, 29);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "New User";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewUserButton_Click;
            // 
            // dataGWWorks
            // 
            dataGWWorks.AllowUserToAddRows = false;
            dataGWWorks.AllowUserToDeleteRows = false;
            dataGWWorks.AllowUserToResizeRows = false;
            dataGWWorks.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGWWorks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGWWorks.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGWWorks.Location = new Point(70, 82);
            dataGWWorks.Name = "dataGWWorks";
            dataGWWorks.ReadOnly = true;
            dataGWWorks.RowHeadersWidth = 51;
            dataGWWorks.RowTemplate.Height = 29;
            dataGWWorks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGWWorks.Size = new Size(674, 321);
            dataGWWorks.TabIndex = 3;
            dataGWWorks.CellDoubleClick += DataGWWorks_CellDoubleClick;
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
            // UserView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 479);
            Controls.Add(WorkNavButton);
            Controls.Add(dataGWWorks);
            Controls.Add(button1);
            Name = "UserView";
            Text = "User Navigation";
            ((System.ComponentModel.ISupportInitialize)dataGWWorks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dataGWWorks;
        private Button WorkNavButton;
    }
}