namespace TaskManager.WorkControl
{
    partial class GroupCreation
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
            CreateButton = new Button();
            listMembers = new ListView();
            label5 = new Label();
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
            // CreateButton
            // 
            CreateButton.Location = new Point(308, 415);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(180, 29);
            CreateButton.TabIndex = 6;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // listMembers
            // 
            listMembers.CheckBoxes = true;
            listMembers.Location = new Point(101, 284);
            listMembers.Name = "listMembers";
            listMembers.Size = new Size(604, 116);
            listMembers.TabIndex = 10;
            listMembers.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 261);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 11;
            label5.Text = "Members";
            // 
            // GroupCreation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 463);
            Controls.Add(label5);
            Controls.Add(listMembers);
            Controls.Add(CreateButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbDescription);
            Controls.Add(tbName);
            Name = "GroupCreation";
            Text = "Create Group";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private TextBox tbDescription;
        private Label label1;
        private Label label2;
        private Button CreateButton;
        private ListView listMembers;
        private Label label5;
    }
}