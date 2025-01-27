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
    public partial class TrainerDietplan : Form
    {
        public TrainerDietplan()
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
            TrainerWorkoutplan w = new TrainerWorkoutplan();
            w.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageSession m = new ManageSession();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrainerCatalogue c = new TrainerCatalogue();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MealPlan m = new MealPlan("");
            m.Show();
            this.Hide();
        }
    }
}
