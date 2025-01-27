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
    public partial class RegisterGym : Form
    {
        public RegisterGym()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OwnerHome o = new OwnerHome();
            o.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gname = textBox1.Text;
            insertIntoGym(gname);
            OwnerHome o = new OwnerHome();
            o.Show();
            this.Hide();
        }
        private void insertIntoGym(string gname)
        {
         
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            connection.Open();
            SqlCommand command;
            string query = "Insert into gym(gymId, userId, gymName, approvalStatus) " +
                          "Values ((SELECT MAX(gymId) + 1 From gym), @userid, " +
                          "@gnam, 'Pending')";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@gnam", gname);
            command.Parameters.AddWithValue("@userId", programMode.userId);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            MessageBox.Show("REQUEST FORWARDED FOR APPROVAL");
        }
    }
}
