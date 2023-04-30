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
            listWorks = new ListBox();
            listView1 = new ListView();
            Name = new ColumnHeader();
            Description = new ColumnHeader();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "New Task";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewTaskButton_Click;
            // 
            // listWorks
            // 
            listWorks.FormattingEnabled = true;
            listWorks.ItemHeight = 20;
            listWorks.Location = new Point(59, 132);
            listWorks.Name = "listWorks";
            listWorks.Size = new Size(475, 104);
            listWorks.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Name, Description });
            listView1.Cursor = Cursors.IBeam;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(70, 268);
            listView1.Name = "listView1";
            listView1.RightToLeft = RightToLeft.No;
            listView1.Size = new Size(464, 121);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // WorkView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 479);
            Controls.Add(listView1);
            Controls.Add(listWorks);
            Controls.Add(button1);
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button button1;
        private ListBox listWorks;
        private ListView listView1;
        private ColumnHeader Name;
        private ColumnHeader Description;
    }
}