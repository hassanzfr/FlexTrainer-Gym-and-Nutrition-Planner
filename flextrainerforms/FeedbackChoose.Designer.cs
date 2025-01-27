namespace flextrainer
{
    partial class FeedbackChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackChoose));
            button7 = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.BackgroundImageLayout = ImageLayout.Zoom;
            button7.Cursor = Cursors.AppStarting;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseDownBackColor = Color.White;
            button7.FlatAppearance.MouseOverBackColor = Color.White;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button7.ForeColor = Color.FromArgb(78, 210, 146);
            button7.Location = new Point(159, 266);
            button7.Name = "button7";
            button7.Size = new Size(402, 347);
            button7.TabIndex = 54;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.AppStarting;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(78, 210, 146);
            button1.Location = new Point(749, 266);
            button1.Name = "button1";
            button1.Size = new Size(402, 347);
            button1.TabIndex = 55;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            button2.Location = new Point(74, 60);
            button2.Name = "button2";
            button2.Size = new Size(74, 84);
            button2.TabIndex = 56;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // FeedbackChoose
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1262, 753);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button7);
            Name = "FeedbackChoose";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FeedbackChoose";
            Load += FeedbackChoose_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button7;
        private Button button1;
        private Button button2;
    }
}