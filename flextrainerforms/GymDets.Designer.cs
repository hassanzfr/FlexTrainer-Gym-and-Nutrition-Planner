namespace flextrainer
{
    partial class GymDets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GymDets));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.FromArgb(214, 37, 96);
            textBox1.Location = new Point(187, 69);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Gym Name";
            textBox1.Size = new Size(425, 78);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.FromArgb(214, 37, 96);
            textBox2.Location = new Point(187, 162);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Address";
            textBox2.Size = new Size(353, 45);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.ForeColor = Color.FromArgb(214, 37, 96);
            textBox3.Location = new Point(982, 84);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Rating";
            textBox3.Size = new Size(80, 34);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.ForeColor = Color.FromArgb(214, 37, 96);
            textBox4.Location = new Point(221, 263);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Trainer List";
            textBox4.Size = new Size(263, 34);
            textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.ForeColor = Color.FromArgb(214, 37, 96);
            textBox5.Location = new Point(551, 263);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Customer Satisfaction";
            textBox5.Size = new Size(221, 29);
            textBox5.TabIndex = 8;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.ForeColor = Color.FromArgb(214, 37, 96);
            textBox6.Location = new Point(841, 268);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Membership Growth";
            textBox6.Size = new Size(221, 29);
            textBox6.TabIndex = 9;
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.ForeColor = Color.FromArgb(214, 37, 96);
            textBox7.Location = new Point(551, 511);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Financial Performance";
            textBox7.Size = new Size(221, 29);
            textBox7.TabIndex = 10;
            // 
            // textBox8
            // 
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox8.ForeColor = Color.FromArgb(214, 37, 96);
            textBox8.Location = new Point(841, 511);
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "Attendance Rate";
            textBox8.Size = new Size(221, 29);
            textBox8.TabIndex = 11;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Cursor = Cursors.AppStarting;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(78, 210, 146);
            button2.Location = new Point(80, 64);
            button2.Name = "button2";
            button2.Size = new Size(74, 84);
            button2.TabIndex = 48;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // GymDets
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1262, 753);
            Controls.Add(button2);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            Name = "GymDets";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GymDets";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Button button2;
    }
}