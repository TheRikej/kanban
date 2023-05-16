﻿using System.Windows.Forms;
using System.Xml.Linq;

namespace TaskManager.WinForms
{
    partial class UserEdit
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
            tbEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            EditButton = new Button();
            label3 = new Label();
            tbPassword = new TextBox();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(102, 49);
            tbName.Name = "tbName";
            tbName.Size = new Size(604, 27);
            tbName.TabIndex = 0;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(102, 112);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(604, 27);
            tbEmail.TabIndex = 1;
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
            // EditButton
            // 
            EditButton.Location = new Point(291, 232);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(180, 29);
            EditButton.TabIndex = 3;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 155);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 11;
            label3.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(101, 178);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(605, 27);
            tbPassword.TabIndex = 2;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // UserEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 284);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(EditButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbEmail);
            Controls.Add(tbName);
            Name = "UserEdit";
            Text = "View/Edit User";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox tbName;
        private TextBox tbEmail;
        private Label label1;
        private Label label2;
        private Button EditButton;

        #endregion

        private Label label3;
        private TextBox tbPassword;
    }
}