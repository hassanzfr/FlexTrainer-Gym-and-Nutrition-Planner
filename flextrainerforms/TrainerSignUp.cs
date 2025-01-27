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
    public partial class TrainerSignUp : Form
    {
        public TrainerSignUp()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                email = textBox1.Text,
                uname = textBox2.Text,
                pw = textBox3.Text,
                fname = textBox4.Text,
                lname = textBox5.Text,
                age = textBox6.Text,
                address = textBox7.Text,
                cnic = textBox8.Text,
                experience = textBox9.Text,
                specialty = textBox10.Text,
                gymcity = textBox11.Text;
            insertIntoAccount(uname, pw);
            insertIntoUsers(getUserID(), fname, lname, int.Parse(age), address, email, cnic, specialty, experience, gymcity);
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private string getUserID()
        {
            string memberId = "T";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string query = "SELECT COUNT(userId) AS memberCount FROM users;";
            command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("memberCount")))
                {
                    string temp = reader["memberCount"].ToString();
                    memberId += temp.ToString();

                }
                else
                {
                    memberId = "0";
                }
            }
            else
            {
                memberId = "0";
            }
            reader.Close();
            connection.Close();

            return memberId;
        }
        private void insertIntoUsers(string userId, string fname, string lname, int age, string address, string email, string cnic, string specialty, string experience, string gymcity)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into Users (userId, accountId, roles, fname, lname, age, userAddress, email, cnic) " +
                           "VALUES (@userId,(SELECT MAX(accountId) FROM account), 'Trainer' ,@fname, @lname, @age, @userAddress, @email, @cnic);";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);
            //command.Parameters.AddWithValue("@accountId", accountId);
            command.Parameters.AddWithValue("@fname", fname);
            command.Parameters.AddWithValue("@lname", lname);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@userAddress", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@cnic", cnic);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            insertIntoTrainer(userId, specialty, experience,gymcity);
        }
        private void insertIntoAccount(string usernam, string password)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string query = "Insert into account(accountId, userName, passwords, currStatus) " +
                           "Values ((SELECT MAX(accountId) + 1 FROM account), @username, " +
                           "@password, 'Inactive')";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", usernam);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        private void insertIntoTrainer(string uid, string specialty, string experience, string gymcity)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into trainer (userId, gymId, specialization, experience, rating, NoOfClients) " +
                           "VALUES (@userID, (SELECT gymId FROM gym WHERE gymName = @gymc), @special ,@exp, 0, 0);";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@special", specialty);
            command.Parameters.AddWithValue("@userID", uid);
            command.Parameters.AddWithValue("@exp", experience);
            command.Parameters.AddWithValue("@gymc", gymcity);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
