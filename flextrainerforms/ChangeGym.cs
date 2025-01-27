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
    public partial class ChangeGym : Form
    {
        public ChangeGym()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHome uh = new UserHome();
            this.Hide();
            uh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHome u = new UserHome();
            u.Show();
            this.Hide();
        }
    }
}
