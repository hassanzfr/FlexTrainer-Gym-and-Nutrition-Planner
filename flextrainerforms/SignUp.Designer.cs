namespace flextrainer
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(236, 236, 236);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.AppStarting;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(236, 236, 236);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 236, 236);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(114, 282);
            button1.Name = "button1";
            button1.Size = new Size(410, 43);
            button1.TabIndex = 3;
            button1.Text = "Sign-Up As A Member";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(236, 236, 236);
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Cursor = Cursors.AppStarting;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(236, 236, 236);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 236, 236);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(29, 94, 180);
            button2.Location = new Point(118, 376);
            button2.Name = "button2";
            button2.Size = new Size(410, 43);
            button2.TabIndex = 4;
            button2.Text = "Sign-Up As A Trainer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(236, 236, 236);
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Cursor = Cursors.AppStarting;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(236, 236, 236);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 236, 236);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.FromArgb(178, 143, 247);
            button3.Location = new Point(121, 472);
            button3.Name = "button3";
            button3.Size = new Size(410, 43);
            button3.TabIndex = 5;
            button3.Text = "Sign-Up As An Owner";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(51, 547);
            label1.Name = "label1";
            label1.Size = new Size(535, 104);
            label1.TabIndex = 7;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1262, 753);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(227, 23, 23);
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUp";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}