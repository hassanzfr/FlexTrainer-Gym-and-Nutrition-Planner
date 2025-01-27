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
    public partial class WorkoutPlan : Form
    {
        int displayId;
        string planName1 = "";
        string planName2 = "";
        string planName3 = "";
        public WorkoutPlan()
        {
            InitializeComponent();
            displayId = 0;
            displayDietplans();
        }
        private void displayDietplans()
        {
            List<string[]> DietData = new List<string[]>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string selectQuery = "select p.planName, p.creatorId, w.diffLevel, w.workoutDesc FROM workout_plan w join plans p on p.planId = w.planId";

            command = new SqlCommand(selectQuery, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] rowData = new string[4];
                rowData[0] = reader["planName"].ToString();
                rowData[1] = reader["creatorId"].ToString();
                rowData[2] = reader["diffLevel"].ToString();
                rowData[3] = reader["workoutDesc"].ToString();
                DietData.Add(rowData);
            }
            reader.Close();

            if (DietData.Count > 0 && displayId < DietData.Count)
            {

                textBox2.Text = DietData[displayId][0];
                planName1 = textBox2.Text;
                textBox1.Text = DietData[displayId][1];
                textBox11.Text = DietData[displayId][2];
                textBox13.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;

                textBox5.Text = DietData[displayId][0];
                planName2 = textBox1.Text;
                textBox3.Text = DietData[displayId][1];
                textBox7.Text = DietData[displayId][2];
                textBox9.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;

                textBox6.Text = DietData[displayId][0];
                planName3 = textBox3.Text;
                textBox4.Text = DietData[displayId][1];
                textBox15.Text = DietData[displayId][2];
                textBox16.Text = DietData[displayId][3];
                if (displayId + 1 < DietData.Count)
                    displayId += 1;
            }

            connection.Close();
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

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            WorkoutDays workoutDays = new WorkoutDays(planName1);
            workoutDays.Show();
            this.Hide();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            WorkoutDays workoutDays = new WorkoutDays("");
            workoutDays.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WorkoutDays workoutDays = new WorkoutDays(planName2);
            workoutDays.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WorkoutDays workoutDays = new WorkoutDays(planName3);
            workoutDays.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkoutSubmit workoutSubmit = new WorkoutSubmit();
            this.Hide();
            workoutSubmit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DietPlan dietPlan = new DietPlan();
            dietPlan.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SessionDets d = new SessionDets();
            d.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FeedbackChoose f = new FeedbackChoose();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayDietplans();
        }
    }
}
