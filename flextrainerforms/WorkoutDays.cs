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
    public partial class WorkoutDays : Form
    {
        string planName;
        public WorkoutDays(string a)
        {
            planName = a;
            InitializeComponent();
            displayDietplans();
        }

        private void WorkoutDays_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkoutPlan plan = new WorkoutPlan();
            plan.Show();
            this.Hide();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            ExerciseDet exerciseDet = new ExerciseDet();
            exerciseDet.Show();
            this.Hide();
        }
        private void displayDietplans()
        {
            List<string[]> DietData = new List<string[]>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string selectQuery = @"SELECT p.planName, p.creatorId, wp.workoutDesc, dre.exName1 AS 'Exercise1', dre.exName2 AS 'Exercise2', dre.exName3 AS 'Exercise3'
                        FROM daily_routine_conatins_exercise dre
                        JOIN plans p ON dre.planId = p.planId
                        JOIN workout_plan wp ON p.planId = wp.planId
                        WHERE p.planName = @planName;";

            command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@planName", planName);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] rowData = new string[6];
                rowData[0] = reader["planName"].ToString();
                rowData[1] = reader["creatorId"].ToString();
                rowData[2] = reader["workoutDesc"].ToString();
                rowData[3] = reader["Exercise1"].ToString();
                rowData[4] = reader["Exercise2"].ToString();
                rowData[5] = reader["Exercise3"].ToString();
                DietData.Add(rowData);
            }
            reader.Close();

            if (DietData.Count > 0)
            {

                textBox2.Text = DietData[0][0];
                planName = textBox2.Text;
                textBox1.Text = DietData[0][1];
                textBox5.Text = DietData[0][2];

                textBox10.Text = DietData[0][3];
                textBox12.Text = DietData[0][4];
                textBox13.Text = DietData[0][5];

                textBox14.Text = DietData[1][3];
                textBox15.Text = DietData[1][4];
                textBox16.Text = DietData[1][5];

                textBox18.Text = DietData[2][3];
                textBox17.Text = DietData[2][4];
                textBox22.Text = DietData[2][5];

                textBox19.Text = DietData[3][3];
                textBox20.Text = DietData[3][4];
                textBox21.Text = DietData[3][5];

            }

            connection.Close();
        }
    }
}
