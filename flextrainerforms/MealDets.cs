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
    public partial class MealDets : Form
    {
        public MealDets()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MealPlan p = new MealPlan("");
            p.Show();
            this.Hide();
        }
    }
}
