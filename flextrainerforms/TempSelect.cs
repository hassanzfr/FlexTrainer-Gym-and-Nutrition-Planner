using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flextrainer
{
    public partial class TempSelect : Form
    {
        public TempSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHome uh = new UserHome();
            this.Hide();
            uh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrainerHome uh = new TrainerHome();
            this.Hide();
            uh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OwnerHome uh = new OwnerHome();
            this.Hide();
            uh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminHome uh = new AdminHome();
            this.Hide();
            uh.Show();
        }
    }
}
