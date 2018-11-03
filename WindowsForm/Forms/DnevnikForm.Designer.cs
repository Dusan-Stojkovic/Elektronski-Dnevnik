namespace WindowsForms
{
    partial class Dnevnik
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
            this.ProfessorWelcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.SubjectComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GradesTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.AverageLabel = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.ProfessorStatsLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProfessorWelcome
            // 
            this.ProfessorWelcome.AutoSize = true;
            this.ProfessorWelcome.Location = new System.Drawing.Point(23, 18);
            this.ProfessorWelcome.Name = "ProfessorWelcome";
            this.ProfessorWelcome.Size = new System.Drawing.Size(96, 13);
            this.ProfessorWelcome.TabIndex = 0;
            this.ProfessorWelcome.Text = "ProfessorWelcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odeljenje";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Učenik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Predmet";
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(80, 57);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(121, 21);
            this.ClassComboBox.TabIndex = 4;
            this.ClassComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassComboBox_SelectedIndexChanged);
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(80, 86);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(121, 21);
            this.StudentComboBox.TabIndex = 5;
            this.StudentComboBox.SelectedIndexChanged += new System.EventHandler(this.StudentComboBox_SelectedIndexChanged);
            // 
            // SubjectComboBox
            // 
            this.SubjectComboBox.FormattingEnabled = true;
            this.SubjectComboBox.Location = new System.Drawing.Point(80, 113);
            this.SubjectComboBox.Name = "SubjectComboBox";
            this.SubjectComboBox.Size = new System.Drawing.Size(121, 21);
            this.SubjectComboBox.TabIndex = 6;
            this.SubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.SubjectComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ocene";
            // 
            // GradesTextBox
            // 
            this.GradesTextBox.Location = new System.Drawing.Point(80, 140);
            this.GradesTextBox.Name = "GradesTextBox";
            this.GradesTextBox.Size = new System.Drawing.Size(121, 20);
            this.GradesTextBox.TabIndex = 8;
            this.GradesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GradesTextBox_KeyPress);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(56, 166);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 9;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AverageLabel
            // 
            this.AverageLabel.AutoSize = true;
            this.AverageLabel.Location = new System.Drawing.Point(227, 147);
            this.AverageLabel.Name = "AverageLabel";
            this.AverageLabel.Size = new System.Drawing.Size(46, 13);
            this.AverageLabel.TabIndex = 10;
            this.AverageLabel.Text = "Prosek: ";
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(299, 166);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 11;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ProfessorStatsLabel
            // 
            this.ProfessorStatsLabel.AllowDrop = true;
            this.ProfessorStatsLabel.AutoSize = true;
            this.ProfessorStatsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProfessorStatsLabel.Location = new System.Drawing.Point(230, 16);
            this.ProfessorStatsLabel.Name = "ProfessorStatsLabel";
            this.ProfessorStatsLabel.Size = new System.Drawing.Size(103, 15);
            this.ProfessorStatsLabel.TabIndex = 21;
            this.ProfessorStatsLabel.Text = "ProfessorStatsLabel";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(218, 166);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 24;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(137, 166);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 25;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // Dnevnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 208);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ProfessorStatsLabel);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.AverageLabel);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.GradesTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SubjectComboBox);
            this.Controls.Add(this.StudentComboBox);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProfessorWelcome);
            this.Name = "Dnevnik";
            this.Text = "Dnevnik";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProfessorWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.ComboBox StudentComboBox;
        private System.Windows.Forms.ComboBox SubjectComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GradesTextBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label AverageLabel;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label ProfessorStatsLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UndoButton;
    }
}