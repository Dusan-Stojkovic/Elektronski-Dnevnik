using System;
using System.Collections.Generic;

namespace DemoLibrary
{
    public class Student:IPersons
    {
        private SQL_Ocene sql = new SQL_Ocene();

        public Student() { }

        public Student(string name,string surname)
        {
            UniqueID = sql.GetStudentID(name,surname);
            this.Name = name;
            this.Surname = surname;
        }

        public void NewGrades(string Subject)
        {
            Grades = new Grades(UniqueID, Subject);
        }

        public List<string> GetStudentList(string Class)
        {
            List<string> temp = sql.GetStudentNames(Class);
            return temp;
        }

        public void ReadFullNameFromDB()
        {
            throw new NotImplementedException();
        }

        public void ReadListOfPersons()
        {
            throw new NotImplementedException();
        }

        private int id;
        public int UniqueID
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
