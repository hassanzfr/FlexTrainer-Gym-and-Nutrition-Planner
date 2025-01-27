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
    public partial class AdminHome : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
        public AdminHome()
        {
            InitializeComponent();
            LoadRequestData();
            LoadRequestIds();
        }
        void LoadRequestIds()
        {
            comboBox1.Items.Clear();

            string query = "SELECT reqId FROM requests";

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["reqId"]);
            }

            conn.Close();
        }

        void LoadRequestData()
        {
            DataTable requestTable = new DataTable();

            requestTable.Columns.Add("RequestID", typeof(int));
            requestTable.Columns.Add("UserID", typeof(string));
            requestTable.Columns.Add("UserName", typeof(string));
            requestTable.Columns.Add("Location", typeof(string)); // Assuming "location" corresponds to a column in the users table
            requestTable.Columns.Add("Request", typeof(string)); // Assuming "request" corresponds to a column in the requests table
            requestTable.Columns.Add("Role", typeof(string));
            requestTable.Columns.Add("ApprovalStatus", typeof(string)); // Assuming "currStatus" corresponds to a column in the requests table

            string query = @"SELECT R.reqId, U.userId, A.userName, R.locationn AS Location, R.request, R.roles AS Role, R.currStatus AS ApprovalStatus
                     FROM requests R
                     JOIN users U ON R.userId = U.userId
                     JOIN account A ON U.accountId = A.accountId";

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                requestTable.Rows.Add(reader["reqId"], reader["userId"], reader["userName"], reader["Location"], reader["Request"], reader["Role"], reader["ApprovalStatus"]);
            }

            conn.Close();
            dataGridView1.DataSource = requestTable;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AuditLog a = new AuditLog();
            a.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                decimal reqIdDecimal = (decimal)comboBox1.SelectedItem;
                int reqId = Convert.ToInt32(reqIdDecimal);
                string query = @"UPDATE requests SET currStatus = 'Approved' WHERE reqId = @reqId";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@reqId", reqId);

                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Request Approved Successfully!");
                    LoadRequestIds();
                    LoadRequestData();
                }
                else
                {
                    MessageBox.Show("Failed to Approve Request!");
                }
            }
            else
            {
                MessageBox.Show("Please select a Request ID from the ComboBox.");
            }
        }

        private void ShowTrainersOnly()
        {
            string query = @"SELECT R.reqId AS 'RequestID', U.userId AS 'UserID', A.userName AS 'UserName', CONCAT(U.fname, ' ', U.lname) AS 'FullName', R.request AS 'Request', R.roles AS 'Role', R.currStatus AS 'ApprovalStatus'
                    FROM requests R
                    JOIN users U ON R.userId = U.userId
                    JOIN account A ON U.accountId = A.accountId
                    WHERE R.roles = 'Trainer'";

            ExecuteQueryAndLoadData(query);
        }

        private void ShowOwnersOnly()
        {
            string query = @"SELECT R.reqId AS 'RequestID', U.userId AS 'UserID', A.userName AS 'UserName', CONCAT(U.fname, ' ', U.lname) AS 'FullName', R.request AS 'Request', R.roles AS 'Role', R.currStatus AS 'ApprovalStatus'
                    FROM requests R
                    JOIN users U ON R.userId = U.userId
                    JOIN account A ON U.accountId = A.accountId
                    WHERE R.roles = 'Owner'";

            ExecuteQueryAndLoadData(query);
        }

        private void ShowGymsOnly()
        {
            string query = @"SELECT R.reqId AS 'RequestID', U.userId AS 'UserID', A.userName AS 'UserName', CONCAT(U.fname, ' ', U.lname) AS 'FullName', R.request AS 'Request', R.roles AS 'Role', R.currStatus AS 'ApprovalStatus'
                    FROM requests R
                    JOIN users U ON R.userId = U.userId
                    JOIN account A ON U.accountId = A.accountId
                    WHERE R.roles = 'Gym'";

            ExecuteQueryAndLoadData(query);
        }

        private void ExecuteQueryAndLoadData(string query)
        {
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                DataTable requestTable = new DataTable();
                requestTable.Load(reader);

                conn.Close();

                dataGridView1.DataSource = requestTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                decimal reqIdDecimal = (decimal)comboBox1.SelectedItem;
                int reqId = Convert.ToInt32(reqIdDecimal);
                string query = @"UPDATE requests SET currStatus = 'Rejected' WHERE reqId = @reqId";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@reqId", reqId);

                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Request Rejected Successfully!");
                    LoadRequestIds();
                    LoadRequestData();
                }
                else
                {
                    MessageBox.Show("Failed to process Request!");
                }
            }
            else
            {
                MessageBox.Show("Please select a Request ID from the ComboBox.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTrainersOnly();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowOwnersOnly();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowGymsOnly();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadRequestData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            reports f2 = new reports();
            f2.Show();
            this.Hide();
        }
    }
}
