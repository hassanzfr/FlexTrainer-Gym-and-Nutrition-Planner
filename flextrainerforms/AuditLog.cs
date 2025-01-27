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
    public partial class AuditLog : Form
    {
        public AuditLog()
        {
            InitializeComponent();
            LoadAuditLogData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome a = new AdminHome();
            a.Show();
            this.Hide();
        }
        void LoadAuditLogData()
        {
            DataTable auditLogTable = new DataTable();

            auditLogTable.Columns.Add("AuditID", typeof(int));
            auditLogTable.Columns.Add("Details", typeof(string));
            auditLogTable.Columns.Add("Date", typeof(DateTime));

            string query = @"SELECT aId AS AuditID, details AS Details, datee AS Date
                     FROM audit_log";
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False");
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                auditLogTable.Rows.Add(reader["AuditID"], reader["Details"], reader["Date"]);
            }

            conn.Close();
            dataGridView1.DataSource = auditLogTable;
        }

    }
}
