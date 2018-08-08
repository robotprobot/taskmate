using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoApp
{
    public partial class Todo : Form
    {
        public Todo()
        {
            InitializeComponent();
        }

        private void changeLogin_Click(object sender, EventArgs e)
        {
            //Declare userName and assign input box value to it
            string userName = Microsoft.VisualBasic.Interaction.InputBox("Choose new user name", "Prompt", "");
            //If user cancels
            if (userName.Equals(""))
            {
                MessageBox.Show("Login details not changed");
            }
            //If OK pressed
            else
            {
                //Declare passWord and assign input box value to it
                string passWord = Microsoft.VisualBasic.Interaction.InputBox("Choose new password", "Prompt", "");
                if (passWord.Equals(""))
                {
                    MessageBox.Show("Login details not changed");
                }
                else
                {
                    //Convert username and password to bytes
                    var newDetails = Encoding.UTF8.GetBytes(userName + passWord);
                    //Convert bytes to base64 encoded string
                    var newDetailsEncoded = System.Convert.ToBase64String(newDetails);
                    //Write to file and confirm
                    System.IO.File.WriteAllText(@"Login.txt", newDetailsEncoded);
                    //Confirm
                    MessageBox.Show("Login details changed");
                }
            }
        }

        private void Todo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.db' table. You can move, or remove it, as needed.
            this.dbTableAdapter1.Fill(this.dbDataSet.db);
            // TODO: This line of code loads data into the 'dbDataSet.db' table. You can move, or remove it, as needed.

        }

        private void saveDB_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                dbBindingSource.EndEdit();
                dbTableAdapter1.Update(dbDataSet.db);
                //Super important next line so visible copy always matches DB
                dbTableAdapter1.Fill(dbDataSet.db);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error while saving To Do List");
            }
        }

        private void dbBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var AboutDetails = new AboutDetails();
            Form openformchecker = Application.OpenForms["AboutDetails"];
            if (openformchecker != null)
                openformchecker.Close();
            AboutDetails.Show();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            var Calendar = new Calendar();
            Form openformchecker = Application.OpenForms["Calendar"];
            if (openformchecker != null)
                openformchecker.Close();
            Calendar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}