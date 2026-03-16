using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace inven
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=MSI;Initial Catalog=inventory;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private bool ValidateLogin(string connectionString, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT count(1) FROM login WHERE [userID] = @userID AND [pass] = @pass";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", username);
                    command.Parameters.AddWithValue("@pass", password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    ////Log the login attempt
                    //LogLoginAttempt(username, count == 1); // Logging username and login success/failure

                    return count == 1;


                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Assuming textBox1 is for username input
            string password = textBox2.Text; // Assuming textBox2 is for password input

            if (ValidateLogin(connectionString, username, password))
            {
                Form2 nextForm = new Form2();
                nextForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        // Function to log login attempts
        //private void LogLoginAttempt(string username, bool success)
        //{
        //    string logConnectionString = "Data Source=MSI;Initial Catalog=inventory;Integrated Security=True";

        //    try
        //    {
        //        using (SqlConnection logConnection = new SqlConnection(logConnectionString))
        //        {
        //            string logQuery = "INSERT INTO infotab (Username, LoginTime) VALUES (@Username, @LoginTime)";

        //            using (SqlCommand logCommand = new SqlCommand(logQuery, logConnection))
        //            {
        //                logCommand.Parameters.AddWithValue("@Username", username);
        //                logCommand.Parameters.AddWithValue("@LoginTime", DateTime.Now);

        //                logConnection.Open();
        //                logCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception: log it, display an error message, or perform other actions.
        //        Console.WriteLine("Error occurred: " + ex.Message);
        //    }
        //}
    }
}
