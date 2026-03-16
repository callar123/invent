using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace inven
{
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=MSI;Initial Catalog=inventory;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            // Show Form3
            frm.Show();

            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void display1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=inventory;Integrated Security=True");
            conn.Open();

            string query = "INSERT INTO product VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, GETDATE())";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Value1", textBox1.Text);

                command.Parameters.AddWithValue("@Value2", textBox2.Text);

                command.Parameters.AddWithValue("@Value3", textBox3.Text);

                command.Parameters.AddWithValue("@Value4", textBox4.Text);

                command.Parameters.AddWithValue("@Value4", textBox5.Text);





                command.ExecuteNonQuery();
            }

            conn.Close();
            MessageBox.Show("Data inserted successfully.");
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM product";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display1.BringToFront(); // Brings the panel to the front
            display1.Visible = true; // Optional: makes sure the panel is visible
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display2.BringToFront(); // Brings the panel to the front
            display2.Visible = true; // Optional: makes sure the panel is visible
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
