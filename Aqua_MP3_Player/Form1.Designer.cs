namespace Aqua_MP3_Player
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            panel1 = new Panel();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.MediumAquamarine;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(520, 95);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 11;
            label4.Text = "Next";
            label4.Click += label4_Click;
            label4.MouseDown += label4_MouseDown;
            label4.MouseEnter += label4_MouseEnter;
            label4.MouseLeave += label4_MouseLeave;
            label4.MouseHover += label4_MouseHover;
            label4.MouseUp += label4_MouseUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.MediumAquamarine;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(428, 60);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 10;
            label3.Text = "Reset time";
            label3.Click += label3_Click;
            label3.MouseDown += label3_MouseDown;
            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
            label3.MouseUp += label3_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MediumAquamarine;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(336, 85);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 9;
            label2.Text = "Play/Pause";
            label2.Click += label2_Click;
            label2.MouseDown += label2_MouseDown;
            label2.MouseEnter += label2_MouseEnter;
            label2.MouseLeave += label2_MouseLeave;
            label2.MouseUp += label2_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MediumAquamarine;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(270, 72);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 8;
            label1.Text = "Back";
            label1.Click += label1_Click;
            label1.MouseDown += label1_MouseDown;
            label1.MouseEnter += label1_MouseEnter;
            label1.MouseLeave += label1_MouseLeave;
            label1.MouseUp += label1_MouseUp;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.MidnightBlue;
            pictureBox2.Image = Properties.Resources.Menu;
            pictureBox2.Location = new Point(86, 188);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseDown += pictureBox2_MouseDown;
            pictureBox2.MouseEnter += pictureBox2_MouseEnter;
            pictureBox2.MouseLeave += pictureBox2_MouseLeave;
            pictureBox2.MouseUp += pictureBox2_MouseUp;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BgDefault;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(687, 330);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(593, 222);
            button1.Name = "button1";
            button1.Size = new Size(55, 59);
            button1.TabIndex = 12;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 4);
            label6.Name = "label6";
            label6.Size = new Size(109, 25);
            label6.TabIndex = 14;
            label6.Text = "Song_name";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(270, 264);
            label7.Name = "label7";
            label7.Size = new Size(90, 28);
            label7.TabIndex = 15;
            label7.Text = "RPT OFF";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(520, 212);
            label8.Name = "label8";
            label8.Size = new Size(33, 38);
            label8.TabIndex = 16;
            label8.Text = "0";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDarkDark;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(155, 233);
            button2.Name = "button2";
            button2.Size = new Size(94, 48);
            button2.TabIndex = 17;
            button2.Text = "Repeat";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Location = new Point(270, 208);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 53);
            panel1.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(687, 328);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Aqua MP3 Player";
            TopMost = true;
            TransparencyKey = Color.Cyan;
            Load += Form1_Load;
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private Panel panel1;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
