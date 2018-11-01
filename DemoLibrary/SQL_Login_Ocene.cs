using System;
using System.Data.OleDb;

namespace DemoLibrary
{
    class SQL_Login_Ocene
    {
        public SQL_Login_Ocene() { }

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\SQLDatabases\Login_Ocene.accdb";

        private bool CheckLogin(string usr, string pass)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                //Query for checking Username - Password combination 
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT (*) FROM Logins WHERE Username='" + usr + "' AND Password='" + pass + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //Any output other than 1 is logical error
                        if (reader.GetInt32(0) == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Exception ex = new Exception("In CheckLogin: Reader failed. ");
                        throw ex;
                    }
                }
            }
        }

        //Get Name - Surname of Professor
        public string[] GetImePrezime(string usr, string pass)
        {
            if (CheckLogin(usr, pass))
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Ime,Prezime FROM Logins WHERE Username='" + usr + "' AND Password='" + pass + "'", conn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string[] temp = new string[2];
                            temp[0] = reader.GetString(0);
                            temp[1] = reader.GetString(1);
                            return temp;
                        }
                        else
                        {
                            Exception ex = new Exception("Ime/Prezime does not exist");
                            throw ex;
                        }
                    }
                }
            }
            else
            {
                Exception ex = new Exception("Wrong Username or Password");
                throw ex;
            }

        }

        public int GetID(string usr,string pass)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ProfesorID FROM Logins WHERE Username='" + usr + "' AND Password='" + pass + "'", conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        Exception ex = new Exception("Bad ID");
                        throw ex;
                    }
                }
            }
        }
    }
}
