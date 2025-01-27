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
    public partial class OwnerSignUp : Form
    {
        public OwnerSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                email = textBox2.Text,
                uname = textBox1.Text,
                pw = textBox3.Text,
                fname = textBox4.Text,
                lname = textBox5.Text,
                age = textBox6.Text,
                address = textBox8.Text,
                cnic = textBox7.Text;
            insertIntoAccount(uname, pw);
            insertIntoUsers(getUserID(), fname, lname, int.Parse(age), address, email, cnic);
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
        private string getUserID()
        {
            string memberId = "O";
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
        private void insertIntoUsers(string userId, string fname, string lname, int age, string address, string email, string cnic)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into Users (userId, accountId, roles, fname, lname, age, userAddress, email, cnic) " +
                           "VALUES (@userId,(SELECT MAX(accountId) FROM account), 'Owner' ,@fname, @lname, @age, @userAddress, @email, @cnic);";

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
            insertIntoOwner(userId);
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
        private void insertIntoOwner(string uid)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            DateTime xy = DateTime.Now;
            string xyz = xy.ToString("dd-MM-yyyy");
            string query = "Insert into owner (userId, joinDate) " +
                           "VALUES (@userId, @wxyz);";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@wxyz", xyz);
            command.Parameters.AddWithValue("@userId", uid);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

        }
    }

}
