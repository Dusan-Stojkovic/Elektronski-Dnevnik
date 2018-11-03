using System;
using System.Windows.Forms;
using DemoLibrary;

namespace WindowsForms
{
    public partial class ConfirmationForm : Form
    {

        Dnevnik dn;
        Student student;
        string NewGrade;

        public ConfirmationForm()
        {
            InitializeComponent();
        }

        public ConfirmationForm(Student student, Dnevnik dn)
        {
            InitializeComponent();
            this.dn = dn;
            this.student = student;

            ChangesToGrades();
        }

        private void ChangesToGrades()
        {
            WarningDialog.Text += Environment.NewLine + "Change the grades of " 
                + student.Name + " " + student.Surname + Environment.NewLine;

            NewGrade = student.Grades.Gradesbuffer;    //Make a copy of original grades
            for (int i=0;i<student.Grades.ActionList.Count;i++)
            {
                NewGrade += ", " + student.Grades.ActionList[i];    //Add new grades to string
                if (i == 0) WarningDialog.Text += "Add " + student.Grades.ActionList[i];
                else
                {
                    WarningDialog.Text += ", " + student.Grades.ActionList[i];
                }
            }
            WarningDialog.Text += Environment.NewLine;
            WarningDialog.Text += "To: " + student.Grades.Gradesbuffer + Environment.NewLine;
            WarningDialog.Text += "The old average: " + student.Grades.Average + Environment.NewLine;
            WarningDialog.Text += "The new average: " + student.Grades.GetAverage(NewGrade) + Environment.NewLine;
        }
   
        private void YesButton_Click(object sender, EventArgs e)
        {
            try
            {
                student.Grades.SetGrade(NewGrade,student.ID);
                MessageBox.Show($"Operation completed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    //Operation failure
            }
            dn.ShowAction(student.ID,student.Grades.Subject);
            this.Hide();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            dn.Show();
            this.Hide();
        }
    }
}
