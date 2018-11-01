using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Odeljenja_Form
{
    public partial class Dnevnik : Form
    {
        Professors Professor;
        ClassOfStudents Class;
        Student SelectedStudent;

        public Dnevnik()
        {
            InitializeComponent();
        }

        public Dnevnik(string Name, string Surname, int ID)
        {
            InitializeComponent();

            StudentComboBox.Enabled = false;
            SubjectComboBox.Enabled = false;
            GradesTextBox.Enabled = false;
            UndoButton.Enabled = false;

            ProfessorWelcome.Text = "Welcome, " + Name + " " + Surname;

            Professor = new Professors(Name, Surname, ID);

            ProfessorStatsLabel.Text = "Razredni: " + Professor.HeadOfYear + Environment.NewLine +
                                       "Predaje Odeljenjima: " + ListToString(Professor.TeachingClasses) + 
                                       "Predmete: " + ListToString(Professor.TeachingSubjects);

            foreach (string item in Professor.TeachingClasses)  
            {
                ClassComboBox.Items.Add(item);  //Fills ClassComboBox and keeps this initialized until Logout_Click occurs
            }
        }

        
        private string ListToString(List<string> l)
        {   //Use this to format Labels
            string s=Environment.NewLine;
            foreach (string item in l)
            {
                s = s + item + ", " + Environment.NewLine;
            }
            return s.Substring(0, s.Length - 2) + Environment.NewLine;
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentComboBox.Enabled == false) StudentComboBox.Enabled = true;
            else
            {
                StudentComboBox.SelectedItem = "";
                StudentComboBox.Items.Clear();
                SubjectComboBox.SelectedItem = "";
                SubjectComboBox.Items.Clear();
                SubjectComboBox.Enabled = false;
            }

            Class = new ClassOfStudents(ClassComboBox.SelectedItem.ToString());
            foreach (string student in Class.Students)
            { 
                StudentComboBox.Items.Add(student);
            }
        }

        private void StudentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeStudent(StudentComboBox.Text);

            if (SubjectComboBox.Enabled == false) SubjectComboBox.Enabled = true;
            else
            {
                SubjectComboBox.SelectedItem = "";
                SubjectComboBox.Items.Clear();
            }

            //Setup SubjectsComboBox
            List<string> subjects = Professor.GetSubjects(ClassComboBox.SelectedItem.ToString());
            foreach (string str in subjects)
            {
                SubjectComboBox.Items.Add(str);
            }

        }

        private void MakeStudent(string NameSurname)
        {
            string[] temp = NameSurname.Split(' ');
            SelectedStudent = new Student(temp[0], temp[1]);    //Each time a new student is selected change the SelectedStudent object to mimic the student
        }

        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedStudent.NewGrades(SubjectComboBox.SelectedItem.ToString());
            GradesTextBox.Text = SelectedStudent.Grades.Gradesbuffer;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GradesTextBox.Enabled == false)
                {
                    if (Professor.CheckAccess(SubjectComboBox.SelectedItem.ToString()))     //Professor must teach that subject
                    {
                        //Gradesbuffer = GradesTextBox.Text;
                        GradesTextBox.Enabled = true;
                    }
                    else
                    {
                        Exception ex = new Exception("Access denied. The professor does not teach that subject");
                        throw ex;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GradesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDigit = e.KeyChar >= '1' && e.KeyChar <= '5';

        
            // If we get anything other than a digit, tell the rest of
            // the event processing logic to ignore this event
            // Backspace is handled by UndoButton
            if (!isDigit)
            {
                e.Handled = true;
            }
            else if(isDigit)
            {
                if (!UndoButton.Enabled) UndoButton.Enabled = true;
                if (!SaveButton.Enabled) SaveButton.Enabled = true;
                GradesTextBox.Text = GradesTextBox.Text + ", " + e.KeyChar.ToString();
                SelectedStudent.Grades.ActionList.Add(e.KeyChar.ToString()); // Adds new grade to list
                AverageLabel.Text = (SelectedStudent.Grades.GetAverage(GradesTextBox.Text)).ToString();
                e.Handled = true;
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (!(SelectedStudent.Grades.Gradesbuffer == GradesTextBox.Text))
            {
                SelectedStudent.Grades.ActionList.RemoveAt(SelectedStudent.Grades.ActionList.Count - 1);  //Remove Action from ActionList
                GradesTextBox.Text = GradesTextBox.Text.Substring(0, GradesTextBox.Text.Length - 3);
                AverageLabel.Text = (SelectedStudent.Grades.GetAverage(GradesTextBox.Text)).ToString();
                if (SelectedStudent.Grades.Gradesbuffer == GradesTextBox.Text)
                {
                    GradesTextBox.Enabled = false;
                    UndoButton.Enabled = false;
                    SaveButton.Enabled = false;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm cf = new ConfirmationForm(SelectedStudent, this);
            cf.ShowDialog();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lg = new LoginForm();
            lg.Show();
        }

        public void ShowAction(int ID, string Subject)
        {
            SelectedStudent.Grades = new Grades(ID, Subject);
            GradesTextBox.Text = SelectedStudent.Grades.Gradesbuffer;

            this.Show();
        }
    }
}
