using Microsoft.Identity.Client;
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

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string
                pw = textBox2.Text,
                uname = textBox1.Text;
            programMode.interFace = programMode.getUname(textBox1.Text);
            if (checkactive(uname,pw)) {
                if (login(uname, pw)) {
                    programMode.getUname(uname);
                    getUserID(uname, pw);
                    if (programMode.interFace == 'm' || programMode.interFace == 'M')
                    {
                        MessageBox.Show(programMode.interFace.ToString());
                        UserHome uh = new UserHome();
                        this.Hide();
                        uh.Show();
                    }
                    else if (programMode.interFace == 't' || programMode.interFace == 'T')
                    {
                        MessageBox.Show(programMode.interFace.ToString());
                        TrainerHome uh = new TrainerHome();
                        this.Hide();
                        uh.Show();
                    }
                    else if (programMode.interFace == 'o' || programMode.interFace == 'O')
                    {
                        MessageBox.Show(programMode.interFace.ToString());
                        OwnerHome uh = new OwnerHome();
                        this.Hide();
                        uh.Show();
                    }
                    else if (programMode.interFace == 'a' || programMode.interFace == 'A')
                    {
                        MessageBox.Show(programMode.interFace.ToString());
                        AdminHome uh = new AdminHome();
                        this.Hide();
                        uh.Show();
                    }
                    else {
                        MessageBox.Show(programMode.interFace.ToString());
                        MessageBox.Show("An unexpected error has occurred");
                    }
                }
            }

            
        }
        private void getUserID(string uname, string pwd) {
            string userId = null;

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                string query = "SELECT U.userId FROM Users U INNER JOIN Account A ON U.accountId = A.accountId WHERE A.userName = @userName AND A.passwords = @password;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", uname); 
                    command.Parameters.AddWithValue("@password", pwd); 

                    programMode.userId = command.ExecuteScalar()?.ToString();
                }
            }
        }
        private bool checkactive(string username, string pw) {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "SELECT currStatus FROM account WHERE userName = @username AND passwords = @pw";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pw", pw);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader["currStatus"].ToString() == "active" || reader["currStatus"].ToString() == "Active")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Your approval request is still pending, try again later !!");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("An Error Occurred");
                return false;
            }
            reader.Close();
            connection.Close();
        }
        private bool login(string username, string password) 
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "SELECT passwords FROM account WHERE userName = @username AND passwords = @pw";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pw", password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (password == reader["passwords"].ToString())
                {
                    return true;
                }
                else {
                    MessageBox.Show("PASSWORD INCORRECT !!");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("An Error Occurred");
                return false;
            }
            reader.Close();
            connection.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            this.Hide();
            // Show the SignUp form
            signUpForm.Show();

        }
    }
    public static class programMode
    {
        public static char getUname(string uname)
        {
           return GetRole(uname);
        }
        private static char GetRole(string username)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "select u.roles from users u join account a on a.accountId = u.accountId where a.userName = @username group by roles";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader["roles"].ToString() == "member" || reader["roles"].ToString() == "Member")
                {
                    return 'm';
                }
                else if (reader["roles"].ToString() == "admin" || reader["roles"].ToString() == "Admin")
                {
                    return 'a';
                }
                else if (reader["roles"].ToString() == "owner" || reader["roles"].ToString() == "Owner")
                {
                    return 'o';
                }
                else if (reader["roles"].ToString() == "trainer" || reader["roles"].ToString() == "Trainer")
                {
                    return 't';
                }
                else
                {
                    return 'x';
                }

            }
            else
            {
                return 'm';
            }
            reader.Close();
            connection.Close();
        }
        public static char interFace;
        public static string userId;
    }
}
