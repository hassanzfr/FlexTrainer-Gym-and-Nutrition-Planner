using Azure;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace flextrainer
{
    public partial class TrainerHome : Form
    {
        public TrainerHome()
        {
            InitializeComponent();
            getName();
            getavg();
        }

        private void getName() {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                string query = @"SELECT CONCAT(u.fname, ' ', u.lname) AS FullName, 
                                g.gymName AS GymName, 
                                t.experience AS Experience, 
                                t.specialization AS Specialization
                        FROM users u
                        JOIN trainer t ON u.userId = t.UserId
                        JOIN gym g ON t.gymId = g.gymId
                        WHERE u.userId = @userId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", programMode.userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox2.Text = reader["FullName"].ToString();
                    textBox10.Text = reader["GymName"].ToString();
                    textBox1.Text = reader["Experience"].ToString();
                    textBox3.Text = reader["Specialization"].ToString();
                }

                reader.Close();
            }
        }
        private void getavg()
        {
            decimal averageRating = 0;

            // Define your SQL query
            string query = "SELECT ROUND(AVG(ratings), 1) AS rounded_average FROM feedback WHERE trainerId = @trainerId;";

            // Create a SqlConnection using your connection string
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to avoid SQL injection
                    command.Parameters.AddWithValue("@trainerId", programMode.userId);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query to get the average rating
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to decimal
                        if (result != null && result != DBNull.Value)
                        {
                            averageRating = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            // Return the average rating
            textBox5.Text = averageRating.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DietPlan d = new DietPlan();
            d.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkoutPlan workoutPlan = new WorkoutPlan();
            workoutPlan.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageSession sesh = new ManageSession();
            sesh.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeGym g = new ChangeGym();
            g.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TrainerCatalogue c = new TrainerCatalogue();
            c.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
