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
    public partial class FeedbackChoose : Form
    {
        public FeedbackChoose()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TrainerFeedback feed = new TrainerFeedback();
            feed.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GymFeedback feed = new GymFeedback();
            feed.Show();
            this.Hide();

        }

        private void FeedbackChoose_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHome u = new UserHome();
            u.Hide();
            this.Hide();
        }
    }
}
