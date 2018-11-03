using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Professors:IPersons
    {
        SQL_Ocene sql = new SQL_Ocene();

        public Professors() { }

        public Professors(string n, string s,int ID)
        {
            UniqueID = ID;
            Name = n;
            Surname = s;
            ProfessorStatus();
        }

        private void ProfessorStatus()
        {
            HeadOfYear = sql.IsHeadOfYear(name, surname);

            TeachingSubjects = sql.GetProfessorsSubjects(name, surname);

            TeachingClasses = sql.GetProfessorsClasses(name, surname);
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
            get{ return id; }
            set
            {
                id = value;
            }
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

        private string headofyear;
        public string HeadOfYear
        {
            get { return headofyear; }
            set { headofyear = value; }
        }

        private List<string> teachingsubjects=new List<string>();
        public List<string> TeachingSubjects
        {
            get { return teachingsubjects; }
            set { teachingsubjects = value; }
        }
        
        //Improve this
        public List<string> GetSubjects(string Class)
        {
            if (HeadOfYear == Class)
                return sql.GetSubjets(id, Class, true);
            else
                return sql.GetSubjets(id, Class, false);
        }

        private List<string> teachingclasses;
        public List<string> TeachingClasses
        {
            get { return teachingclasses; }
            set { teachingclasses = value; }
        }
    }
}
