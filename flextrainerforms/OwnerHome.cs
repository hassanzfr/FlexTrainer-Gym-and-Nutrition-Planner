using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace flextrainer
{
    public partial class OwnerHome : Form
    {
        public OwnerHome()
        {
            InitializeComponent();
            LoadGymRequests();
            getName();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");

        private void getName() {
            string fullName = "";

            using (conn)//SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT CONCAT(fname, ' ', lname) AS FullName FROM users WHERE userId = @UserId";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@UserId", programMode.userId);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Read the value from the "FullName" column and store it in the fullName variable
                    fullName = reader["FullName"].ToString();
                }

                reader.Close();
            }
            textBox1.Text = fullName;
        }
        private void LoadGymRequests()
        {
            string query = "SELECT * FROM gym WHERE userId = @x;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@x", programMode.userId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable gymRequestsTable = new DataTable();
            gymRequestsTable.Load(reader);
            conn.Close();

            dataGridView1.DataSource = gymRequestsTable;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterGym g = new RegisterGym();
            g.Show();
            this.Hide();
        }
    }
}
