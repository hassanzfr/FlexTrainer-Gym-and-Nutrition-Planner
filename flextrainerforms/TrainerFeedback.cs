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
    public partial class TrainerFeedback : Form
    {
        public TrainerFeedback()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FeedbackChoose f = new FeedbackChoose();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                tname = textBox1.Text,
                rating = textBox2.Text,
                desc = textBox3.Text;
            insertIntoFeedback(tname, rating, desc);
            MessageBox.Show("Feedback has been submitted");
            UserHome home = new UserHome();
            home.Show();
            this.Hide();
        }
        private void insertIntoFeedback(string tname, string rating, string desc)
        {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
                connection.Open();
                SqlCommand command;
                string query = "Insert into feedback (feedbackId, memberId, trainerId, ratings) " +
                               "VALUES ((SELECT MAX(feedbackId) + 1 FROM feedback),@userID, (SELECT userId FROM users WHERE fname = @nam) , @rati);";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", programMode.userId);
                command.Parameters.AddWithValue("@nam", tname);
                command.Parameters.AddWithValue("@rati", rating);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            
        }
    }
}
