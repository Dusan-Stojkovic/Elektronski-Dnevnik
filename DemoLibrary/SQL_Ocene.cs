using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace DemoLibrary
{
    class SQL_Ocene
    {
        public SQL_Ocene() { }

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\SQLDatabases\Ocene.accdb";

        public int GetProfessorID(string name,string surname)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ProfesorID FROM Profesori " +
                                                    "WHERE Profesori.Ime='" + name + "'" + "AND Profesori.Prezime='" + surname + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        Exception ex = new Exception("In SQL_Statements.GetProfessorID: reader.Read() error");
                        throw ex;
                    }
                }

            }
        }

        public string IsHeadOfYear(string name, string surname)
        {
            //Allows Professor to view grades of their pupil
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Odeljenje FROM Odeljenja " +
                                                    "INNER JOIN Profesori ON Profesori.Razredni = Odeljenja.OdeljenjeID " +
                                                    "WHERE Profesori.Ime='" + name + "'" + "AND Profesori.Prezime='" + surname + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }

            }
        }

        public List<string> GetProfessorsSubjects(string name, string surname)
        {
            //Displays which subjects the profesor teaches
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Predmet FROM(Predmet " +
                                                    "INNER JOIN ProfesorPredmet ON ProfesorPredmet.PredmetID = Predmet.PredmetID) " +
                                                    "INNER JOIN Profesori ON ProfesorPredmet.ProfesorID = Profesori.ProfesorID " +
                                                    "WHERE Profesori.Ime='" + name + "'" + "AND Profesori.Prezime='" + surname + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    List<string> temp=new List<string>();
                    while (reader.Read())
                    {
                        temp.Add(reader.GetString(0));
                    }
                    return temp;
                }
            }
        }

        public List<string> GetProfessorsClasses(string name, string surname)
        {
            //Displays to which classes the professor can edit grades
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Odeljenje FROM(Odeljenja " +
                                                    "INNER JOIN ProfesorOdeljenje ON ProfesorOdeljenje.OdeljenjeID = Odeljenja.OdeljenjeID) " +
                                                    "INNER JOIN Profesori ON ProfesorOdeljenje.ProfesorID = Profesori.ProfesorID " +
                                                    "WHERE Profesori.Ime='" + name + "'" + " AND Profesori.Prezime='" + surname + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    List<string> temp = new List<string>();
                    while (reader.Read())
                    {
                        temp.Add(reader.GetString(0));
                    }
                    return temp;
                }
            }
        }

        //Specific for grades class
        public string GetStudentGrades(int id, string Subject)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT OceneCon FROM (Ocene " +
                                                    "INNER JOIN Dnevnik ON Dnevnik.UčenikID = Ocene.UčenikID) " +
                                                    "INNER JOIN Predmet ON Predmet.PredmetID = Ocene.PredmetID " +
                                                    "WHERE Dnevnik.UčenikID ="+id+" AND Predmet.Predmet = '" + Subject + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                    else
                    {
                        Exception ex = new Exception("In StudentGrades: Reader failed");
                        throw ex;
                    }
                }
            }
        }

        //Specific for student class
        public int GetStudentID(string name,string surname)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT UčenikID FROM Dnevnik " +
                                                    "WHERE Dnevnik.Ime ='" + name + "' AND Dnevnik.Prezime = '" + surname + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        Exception ex = new Exception("In GetStudentID: Reader failed");
                        throw ex;
                    }
                }
            }
        }

        //Get names and surnames for ClassOfStudents
        public List<string> GetStudentNames(string Class)  
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Ime,Prezime FROM Dnevnik " +
                                                    "INNER JOIN Odeljenja ON Odeljenja.OdeljenjeID=Dnevnik.OdeljenjeID " +
                                                    "WHERE Odeljenja.Odeljenje='" + Class + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    List<string> NameSurname = new List<string>();
                    while (reader.Read())
                    {
                        string[] temp = new string[2];
                        temp[0] = reader.GetString(0);
                        temp[1] = reader.GetString(1);
                        NameSurname.Add(temp[0] + " " + temp[1]);
                    }
                    return NameSurname;
                }
            }
        }


        //Send to SubjectsComboBox trough Professor class
        public List<string> GetSubjets(int id, string Class ,bool HeadOfYear)
        {
            if (HeadOfYear)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Predmet FROM( Predmet " +
                                                        "INNER JOIN PredmetOdeljenje On PredmetOdeljenje.PredmetID = Predmet.PredmetID) " +
                                                        "INNER JOIN Odeljenja On Odeljenja.OdeljenjeID = PredmetOdeljenje.OdeljenjeID " +
                                                        "WHERE Odeljenja.Odeljenje ='" + Class + "'", conn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> subjects = new List<string>();
                        while (reader.Read())
                        {
                            subjects.Add(reader.GetString(0));
                        }
                        return subjects;
                    }

                }
            }
            else
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Predmet FROM(((Predmet " +
                                                        "INNER JOIN ProfesorPredmet ON ProfesorPredmet.PredmetID = Predmet.PredmetID) " +
                                                        "INNER JOIN Profesori ON ProfesorPredmet.ProfesorID = Profesori.ProfesorID) " +
                                                        "INNER JOIN ProfesorOdeljenje ON Profesori.ProfesorID = ProfesorOdeljenje.ProfesorID) " +
                                                        "INNER JOIN Odeljenja ON ProfesorOdeljenje.OdeljenjeID = Odeljenja.OdeljenjeID " +
                                                        "WHERE Profesori.ProfesorID=" + id + " " +
                                                        "AND Odeljenja.Odeljenje='" + Class + "'", conn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> subjects = new List<string>();
                        while (reader.Read())
                        {
                            subjects.Add(reader.GetString(0));
                        }
                        return subjects;
                    }
                }
            }
        }

        public void SetGrade(string NewGrade,int StudentID, string Subject)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();

                OleDbCommand command1 = new OleDbCommand("UPDATE Ocene " +
                                                         $"SET OceneCon = '{NewGrade}' " +
                                                         "WHERE OceneCon IN (" +
                                                         "SELECT Ocene.OceneCon FROM (Ocene " +
                                                         "INNER JOIN Predmet ON Predmet.PredmetID = Ocene.PredmetID) " +
                                                         "INNER JOIN Dnevnik ON Dnevnik.UčenikID = Ocene.UčenikID " +
                                                         $"WHERE Predmet.Predmet = '{Subject}' AND Dnevnik.UčenikID = {StudentID})", conn);

                command1.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
