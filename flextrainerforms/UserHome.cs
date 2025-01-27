using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace flextrainer
{
    public partial class UserHome : Form
    {
        public UserHome()
        {

            InitializeComponent();
            getName();
        }
        private void getName()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                string query = @"select CONCAT(u.fname,' ',u.lname) AS FullName, u.userAddress, g.gymId
                                from users u 
                                join gym g ON u.userAddress = g.gymName
                                where u.userId = @userID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", programMode.userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox2.Text = reader["FullName"].ToString();
                    textBox10.Text = reader["userAddress"].ToString();
                    textBox3.Text = "GymId: " + reader["gymId"].ToString();
                }

                reader.Close();
            }
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            GymDets d = new GymDets();
            d.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DietPlan plan = new DietPlan();
            plan.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkoutPlan plan = new WorkoutPlan();
            plan.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SessionDets d = new SessionDets();
            d.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeGym changeGym = new ChangeGym();
            changeGym.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FeedbackChoose c = new FeedbackChoose();
            c.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DietCat d = new DietCat();
            d.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MembershipDets membershipDets = new MembershipDets();
            membershipDets.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }
    }
}
