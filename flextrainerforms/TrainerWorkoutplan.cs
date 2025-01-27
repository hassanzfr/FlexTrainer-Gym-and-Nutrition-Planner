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
    public partial class TrainerWorkoutplan : Form
    {
        public TrainerWorkoutplan()
        {
            InitializeComponent();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrainerDietplan t = new TrainerDietplan();
            t.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageSession m = new ManageSession();
            m.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TrainerCatalogue t = new TrainerCatalogue();
            t.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkoutDays w = new WorkoutDays("");
            w.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainerHome t = new TrainerHome();
            t.Show();
            this.Hide();
        }
    }
}
