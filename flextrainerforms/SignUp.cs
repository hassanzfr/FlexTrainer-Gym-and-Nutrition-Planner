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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemberSignUp msignUpForm = new MemberSignUp();
            this.Hide();
            // Show the MemberSignUp form
            msignUpForm.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainerSignUp tsignUpForm = new TrainerSignUp();
            this.Hide();
            // Show the MemberSignUp form
            tsignUpForm.Show();
            // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OwnerSignUp osignUpForm = new OwnerSignUp();
            this.Hide();
            // Show the MemberSignUp form
            osignUpForm.Show();
        }
    }
}
