using System;
using System.Windows.Forms;
using DemoLibrary;

namespace Odeljenja_Form
{
    public partial class LoginForm : Form
    {
        private Login log;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                log = new Login(textBox1.Text, textBox2.Text);
                Dnevnik dn = new Dnevnik(log.ImePrezime[0], log.ImePrezime[1],log.ID);
                dn.Show();
                this.Hide();
            }
            catch (Exception ex) {  MessageBox.Show(ex.Message); }
            //This code is executed if wrong Username or Password is given
            textBox1.Text = "";
            textBox2.Text = "";
            return;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

