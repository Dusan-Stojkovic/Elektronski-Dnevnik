using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odeljenja_Form
{
    public class Grades
    {
        public Grades() { }

        public Grades(int ID, string Subject)
        {
            Gradesbuffer = sql.GetStudentGrades(ID,Subject);
            Average = GetAverage(Gradesbuffer);
            this.Subject = Subject;
        }

        public string Gradesbuffer;  //Holds original GradesTextBox

        public List<string> ActionList = new List<string>();
        /*
         * ActionList is used for undo button,
         * and for ConfirmationForm
         */

        SQL_Ocene sql = new SQL_Ocene();

        public double Average;

        public string Subject { get; set; }

        public double GetAverage(string Grades)
        {
            int numcount = 0;
            double sum = 0;
            string temp = Grades;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Char.IsDigit(temp[i]))
                {
                    ++numcount;
                    sum += Convert.ToInt32(temp[i]) - 48;
                }
            }
            return Math.Round(sum / numcount, 2);
        }

        public void SetGrade(string NewGrade, int ID)
        {
            try
            {
                sql.SetGrade(NewGrade,ID,Subject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
