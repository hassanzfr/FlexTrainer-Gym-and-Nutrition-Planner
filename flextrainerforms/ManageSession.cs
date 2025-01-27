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
    public partial class ManageSession : Form
    {
        public ManageSession()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainerHome t = new TrainerHome();
            t.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrainerHome t = new TrainerHome();
            t.Show();
            this.Hide();
        }
    }
}
