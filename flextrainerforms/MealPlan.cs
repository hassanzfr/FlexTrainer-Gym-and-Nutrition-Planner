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
    public partial class MealPlan : Form
    {
        
        string planName = "";
        public MealPlan(string a)
        {
            planName = a;
            InitializeComponent();
            displayDietplans();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DietPlan d = new DietPlan();
            d.Show();
            this.Hide();
        }
        private void displayDietplans()
        {
            List<string[]> DietData = new List<string[]>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;

            string selectQuery = "SELECT p.planName,p.creatorId,d.purpose,dr.meal1,dr.meal2,dr.meal3 FROM daily_routine dr JOIN plans p ON dr.planId = p.planId join diet_plan d ON dr.planId = d.planId WHERE p.planName = @planN;";

            command = new SqlCommand(selectQuery, connection);

            command.Parameters.AddWithValue("@planN", planName);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] rowData = new string[6];
                rowData[0] = reader["planName"].ToString();
                rowData[1] = reader["creatorId"].ToString();
                rowData[2] = reader["purpose"].ToString();
                rowData[3] = reader["meal1"].ToString();
                rowData[4] = reader["meal2"].ToString();
                rowData[5] = reader["meal3"].ToString();
                DietData.Add(rowData);
            }
            reader.Close();

            if (DietData.Count > 0)
            {
                
                textBox2.Text = DietData[0][0];
                planName = textBox2.Text;
                textBox1.Text = DietData[0][1];
                textBox3.Text = DietData[0][2];

                textBox10.Text = DietData[0][3];
                textBox12.Text = DietData[0][4];
                textBox13.Text = DietData[0][5];

                textBox14.Text = DietData[1][3];
                textBox15.Text = DietData[1][4];
                textBox16.Text = DietData[1][5];

                textBox18.Text = DietData[2][3];
                textBox17.Text = DietData[2][4];
                textBox22.Text = DietData[2][5];

            }

            connection.Close();
        }
    }
}
