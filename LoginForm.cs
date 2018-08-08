using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace demoApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string loadedDetails = System.IO.File.ReadAllText(@"cfg.txt");
            //Declare input variables
            string userName;
            string passWord;
            //User populates variables
            userName = userNameBox.Text;
            passWord = passWordBox.Text;
            //Convert username and password to bytes
            var rawCreds = Encoding.UTF8.GetBytes(userName + passWord);
            //Convert bytes to base64 encoded string
            var encodedCreds = System.Convert.ToBase64String(rawCreds);
            //Check credentials and quit if invalid
            if (loadedDetails == encodedCreds)
            {
                this.Hide();
                timer1.Stop();
                var Todo = new Todo();
                Todo.Closed += (s, args) => this.Close();
                Todo.Show();
            }
            else
            {
                MessageBox.Show("Incorrect credentials. Please try again.");
            }
        }

        // countdown timer start
        private void LoginForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public static int count = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count -= 1;
            countdownBox.Text = "Time remaining: " + count.ToString();
            if (count == 0)
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void countdownBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
