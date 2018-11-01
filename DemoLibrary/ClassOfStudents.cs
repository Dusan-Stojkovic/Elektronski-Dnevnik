using System;
using System.Collections.Generic;

namespace Odeljenja_Form
{
    public class ClassOfStudents
    {
        public ClassOfStudents() { }

        //Used for Number of students in a Class
        public ClassOfStudents(string Class)
        {
            Students = sql.GetStudentNames(Class);    
        }

        private SQL_Ocene sql = new SQL_Ocene();

        private List<string> students;
        public List<string> Students
        {
            get { return students; }
            private set
            {
                students = value;
            }
        }
    }
}
