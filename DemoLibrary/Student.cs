using System;
using System.Collections.Generic;

namespace Odeljenja_Form
{
    public class Student
    {
        private SQL_Ocene sql = new SQL_Ocene();

        public Student() { }

        public Student(string name,string surname)
        {
            ID = sql.GetStudentID(name,surname);
            this.Name = name;
            this.Surname = surname;
        }

        public void NewGrades(string Subject)
        {
            Grades = new Grades(ID, Subject);
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
            }
        }

        public Grades Grades;
    }
}
