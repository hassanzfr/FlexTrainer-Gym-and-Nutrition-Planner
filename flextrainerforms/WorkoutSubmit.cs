﻿using System;
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
    public partial class WorkoutSubmit : Form
    {
        public WorkoutSubmit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                pname = textBox2.Text,
                goal = textBox3.Text,
                difflev = textBox1.Text,
                desc = textBox4.Text,
                d1e1 = textBox10.Text,
                d1e2 = textBox12.Text,
                d1e3 = textBox13.Text,
                d2e1 = textBox14.Text,
                d2e2 = textBox15.Text,
                d2e3 = textBox16.Text,
                d3e1 = textBox18.Text,
                d3e2 = textBox17.Text,
                d3e3 = textBox22.Text,
                d4e1 = textBox19.Text,
                d4e2 = textBox20.Text,
                d4e3 = textBox21.Text;
            InsertIntoPlans(pname);
            InsertIntowp(desc, difflev, goal);
            InsertIntodr(d1e1, d1e2, d1e3);
            InsertIntodr(d2e1, d2e2, d2e3);
            InsertIntodr(d3e1, d3e2, d3e3);
            InsertIntodr(d4e1, d4e2, d4e3);
            WorkoutPlan plan = new WorkoutPlan();
            this.Hide();
            plan.Show();
        }
        
        private void InsertIntoPlans(string pname)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into plans (planId, planName, creatorId, visibility) " +
                           "VALUES ((SELECT MAX(planId) + 1 FROM plans), @planName, @userId , 'Private');";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", programMode.userId);
            command.Parameters.AddWithValue("@planName", pname);

            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
        private void InsertIntowp(string desc, string difflev, string goal)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into workout_plan (planId, workoutDesc, diffLevel, goal) " +
                           "VALUES ((SELECT MAX(planId) FROM plans), @d, @l, @g);";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@d", desc);
            command.Parameters.AddWithValue("@l", difflev);
            command.Parameters.AddWithValue("@g", goal);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
        private void InsertIntodr(string e1, string e2, string e3)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into daily_routine_conatins_exercise (dayNo, planId, exName1, exName2, exName3) " +
                           "VALUES ((SELECT MAX(dayNo) FROM daily_routine_conatins_exercise), (SELECT MAX(planId) FROM plans), @d, @l, @g);";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@d", e1);
            command.Parameters.AddWithValue("@l", e2);
            command.Parameters.AddWithValue("@g", e3);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            WorkoutPlan plan = new WorkoutPlan();
            this.Hide();
            plan.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
