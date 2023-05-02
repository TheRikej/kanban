namespace TaskManager
{
    partial class WorkView
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
            cbFilterStatus = new ComboBox();
            cbFilterPriority = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGWWorks).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(70, 25);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "New Task";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewTaskButton_Click;
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
            dataGWWorks.CellDoubleClick += dataGWWorks_CellDoubleClick;
            // 
            // cbFilterStatus
            // 
            cbFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterStatus.FormattingEnabled = true;
            cbFilterStatus.Items.AddRange(new object[] { "-----", "TODO", "InProgress", "Paused", "Done", "Canceled" });
            cbFilterStatus.Location = new Point(582, 26);
            cbFilterStatus.Name = "cbFilterStatus";
            cbFilterStatus.Size = new Size(151, 28);
            cbFilterStatus.TabIndex = 4;
            cbFilterStatus.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // cbFilterPriority
            // 
            cbFilterPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterPriority.FormattingEnabled = true;
            cbFilterPriority.Items.AddRange(new object[] { "-----", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbFilterPriority.Location = new Point(395, 26);
            cbFilterPriority.Name = "cbFilterPriority";
            cbFilterPriority.Size = new Size(151, 28);
            cbFilterPriority.TabIndex = 5;
            cbFilterPriority.SelectedIndexChanged += cbFilterPriority_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(395, 3);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 6;
            label1.Text = "Min Priority";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(582, 3);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 7;
            label2.Text = "Status";
            // 
            // WorkView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 479);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbFilterPriority);
            Controls.Add(cbFilterStatus);
            Controls.Add(dataGWWorks);
            Controls.Add(button1);
            Name = "WorkView";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGWWorks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button button1;
        private DataGridView dataGWWorks;
        private ComboBox cbFilterStatus;
        private ComboBox cbFilterPriority;
        private Label label1;
        private Label label2;
    }
}