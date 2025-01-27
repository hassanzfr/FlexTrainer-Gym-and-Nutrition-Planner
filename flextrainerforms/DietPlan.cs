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

    public partial class DietPlan : Form
    {
        int displayId;
        string planName1 = "";
        string planName2 = "";
        string planName3 = "";
        public DietPlan()
        {
            InitializeComponent();
            displayId = 0;
            displayDietplans();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHome uh = new UserHome();
            TrainerHome uh1 = new TrainerHome();
            this.Hide();
            if (programMode.interFace == 'm')
                uh.Show();
            else
                uh1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FeedbackChoose ch = new FeedbackChoose();
            ch.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            MealPlan plan = new MealPlan(planName1);
            plan.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MealPlan plan = new MealPlan(planName2);
            plan.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MealPlan plan = new MealPlan(planName3);
            plan.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkoutPlan plan = new WorkoutPlan();
            plan.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SessionDets dets = new SessionDets();
            dets.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubmitDiet s = new SubmitDiet();
            s.Show();
            this.Hide();
        }
        private int getmaxPlan()
        {
            int maxPlan = 0;
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT COUNT(*) FROM plans";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    maxPlan = (int)command.ExecuteScalar();
                }
            }
            return maxPlan;
        }
        private void displayDietplans()
        {
            List<string[]> DietData = new List<string[]>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string selectQuery = "select p.planName, p.creatorId, d.purpose, d.dietDesc FROM diet_plan d join plans p on p.planId = d.planId";

            command = new SqlCommand(selectQuery, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] rowData = new string[4];
                rowData[0] = reader["planName"].ToString();
                rowData[1] = reader["creatorId"].ToString();
                rowData[2] = reader["purpose"].ToString();
                rowData[3] = reader["dietdesc"].ToString();
                DietData.Add(rowData);
            }
            reader.Close();

            if (DietData.Count > 0 && displayId < DietData.Count)
            {
                
                textBox2.Text = DietData[displayId][0];
                planName1 = textBox2.Text;
                textBox4.Text = DietData[displayId][1];
                textBox14.Text = DietData[displayId][2];
                textBox13.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;
                
                textBox1.Text = DietData[displayId][0];
                planName2 = textBox1.Text;
                textBox5.Text = DietData[displayId][1];
                textBox7.Text = DietData[displayId][2];
                textBox8.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;
                
                textBox3.Text = DietData[displayId][0];
                planName3 = textBox3.Text;
                textBox6.Text = DietData[displayId][1];
                textBox18.Text = DietData[displayId][2];
                textBox16.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;
            }

            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            displayDietplans();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
