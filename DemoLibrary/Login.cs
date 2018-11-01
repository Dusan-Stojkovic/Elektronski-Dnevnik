using System;

namespace DemoLibrary
{
    public class Login
    {
        public Login() { }

        public Login(string usr, string pass)
        {
            try
            {
                ImePrezime = sql.GetImePrezime(usr, pass);
                ID = sql.GetID(usr, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        private string[] imeprezime;
        public string[] ImePrezime
        {
            get { return imeprezime; }
            set
            {
                imeprezime = value;
            }
        }

        private SQL_Login_Ocene sql = new SQL_Login_Ocene();
    }
   
}
