using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odeljenja_Form
{
    public class Professors
    {
        public Professors() { }

        public Professors(string n, string s,int ID)
        {
            id = ID;
            Name = n;
            Surname = s;
            Professor_Status();
        }

        private void Professor_Status()
        {
            HeadOfYear = sql.IsHeadOfYear(name, surname);

            TeachingSubjects = sql.GetProfessorsSubjects(name, surname);

            TeachingClasses = sql.GetProfessorsClasses(name, surname);
        }

        public List<string> GetSubjects(string Class)
        {
            if (HeadOfYear == Class)
                return sql.GetSubjets(id, Class, true);
            else
                return sql.GetSubjets(id, Class, false);
        }

        public bool CheckAccess(string Subject)
        {
            foreach (string str in teachingsubjects)
            {
                if (str == Subject) return true;
            }
            return false;
        }

        SQL_Ocene sql = new SQL_Ocene();

        private int id;
        public int ID
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

        private List<string> teachingclasses;
        public List<string> TeachingClasses
        {
            get { return teachingclasses; }
            set { teachingclasses = value; }
        }
    }
}
