namespace TaskManager.WorkControl
{
    partial class WorkCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbName = new TextBox();
            tbDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            CreateButton = new Button();
            dateTimePicker = new DateTimePicker();
            cbPriority = new ComboBox();
            label4 = new Label();
            listAssignees = new ListView();
            label5 = new Label();
            listAssignedGroups = new ListView();
            label6 = new Label();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(102, 49);
            tbName.Name = "tbName";
            tbName.Size = new Size(604, 27);
            tbName.TabIndex = 0;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(102, 112);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(604, 132);
            tbDescription.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 26);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 89);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 255);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 5;
            label3.Text = "Priority";
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(300, 620);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(180, 29);
            CreateButton.TabIndex = 6;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "";
            dateTimePicker.ImeMode = ImeMode.Off;
            dateTimePicker.Location = new Point(101, 279);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(336, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // cbPriority
            // 
            cbPriority.AllowDrop = true;
            cbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPriority.FormattingEnabled = true;
            cbPriority.ImeMode = ImeMode.NoControl;
            cbPriority.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbPriority.Location = new Point(455, 281);
            cbPriority.MaxDropDownItems = 10;
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(251, 28);
            cbPriority.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 255);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 9;
            label4.Text = "Due Date";
            // 
            // listAssignees
            // 
            listAssignees.CheckBoxes = true;
            listAssignees.Location = new Point(102, 337);
            listAssignees.Name = "listAssignees";
            listAssignees.Size = new Size(604, 116);
            listAssignees.TabIndex = 10;
            listAssignees.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 314);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 11;
            label5.Text = "Assignees";
            // 
            // listAssignedGroups
            // 
            listAssignedGroups.CheckBoxes = true;
            listAssignedGroups.Location = new Point(101, 493);
            listAssignedGroups.Name = "listAssignedGroups";
            listAssignedGroups.Size = new Size(604, 121);
            listAssignedGroups.TabIndex = 12;
            listAssignedGroups.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 470);
            label6.Name = "label6";
            label6.Size = new Size(120, 20);
            label6.TabIndex = 13;
            label6.Text = "Assigned Groups";
            // 
            // WorkCreation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 659);
            Controls.Add(label6);
            Controls.Add(listAssignedGroups);
            Controls.Add(label5);
            Controls.Add(listAssignees);
            Controls.Add(label4);
            Controls.Add(cbPriority);
            Controls.Add(dateTimePicker);
            Controls.Add(CreateButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbDescription);
            Controls.Add(tbName);
            Name = "WorkCreation";
            Text = "Create Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private TextBox tbDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button CreateButton;
        private DateTimePicker dateTimePicker;
        private ComboBox cbPriority;
        private Label label4;
        private ListView listAssignees;
        private Label label5;
        private ListView listAssignedGroups;
        private Label label6;
    }
}