using Aqua_MP3_Player.Properties;
using NAudio.Utils;
using System.Diagnostics;

namespace Aqua_MP3_Player
{
    public partial class Form1 : Form
    {
        List<string> playList = new List<string>();
        NAudio.Wave.WaveOutEvent output = new NAudio.Wave.WaveOutEvent();
        bool isPlaying = false;
        string selectedSong;
        int currentSong;
        NAudio.Wave.AudioFileReader? player = null;
        bool repeat = false;
        float volume = 1.0f;



        public Form1()
        {
            InitializeComponent();
            Retro.ApplyRetroFont(this);
            playList = Directory.GetFiles(@"Songs").ToList();
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "Songs listened: " + Settings.Default.ListenedTo.ToString();
            selectedSong = playList[0];
            player = new NAudio.Wave.AudioFileReader(selectedSong);
            label1.BackColor = Color.FromArgb(255, 141, 196, 156);
            label2.BackColor = Color.FromArgb(255, 141, 196, 156);
            label3.BackColor = Color.FromArgb(255, 141, 196, 156);
            label4.BackColor = Color.FromArgb(255, 141, 196, 156);
            label5.BackColor = Color.FromArgb(255, 172, 220, 194);
            label6.BackColor = Color.FromArgb(255, 172, 220, 194);
            label7.BackColor = Color.FromArgb(255, 172, 220, 194);
            label8.BackColor = Color.FromArgb(255, 172, 220, 194);
            panel1.BackColor = Color.FromArgb(255, 172, 220, 194);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InfoDisplay info = new InfoDisplay("Program title here", "The info text goes here.");
            info.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageDisplay msg = new MessageDisplay("Erorr title", "The error details go here.");
            msg.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (output.PlaybackState == NAudio.Wave.PlaybackState.Stopped && repeat)
            {
                Settings.Default.ListenedTo += 1;
                Settings.Default.Save();
                label5.Text = "Songs listened: " + Settings.Default.ListenedTo.ToString();

                // song
                output.Stop();
                output.Dispose();
                player.Dispose();
                selectedSong = playList[currentSong];
                player = new NAudio.Wave.AudioFileReader(selectedSong);
                if (output == null || output.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
                {
                    output.Init(player);
                    output.Play();
                }
                else
                {
                    output.Play();
                }
            }
            else if (output.PlaybackState == NAudio.Wave.PlaybackState.Stopped && !repeat)
            {
                Settings.Default.ListenedTo += 1;
                Settings.Default.Save();
                label5.Text = "Songs listened: " + Settings.Default.ListenedTo.ToString();
                currentSong++;
                if (currentSong >= playList.Count)
                {
                    currentSong = 0;
                }

                label6.Text = Path.GetFileName(playList[currentSong]);
                label8.Text = currentSong.ToString();
                // song
                output.Stop();
                output.Dispose();
                player.Dispose();
                selectedSong = playList[currentSong];
                player = new NAudio.Wave.AudioFileReader(selectedSong);

                if (output == null || output.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
                {

                    output.Init(player);
                    output.Play();
                }
                else
                {
                    output.Play();
                }

            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Retro.MoveWindow(sender, e, Handle);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Resources.BgMenu2;
            pictureBox2.BackColor = Color.MediumAquamarine;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.BgMenu1;

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.BgDefault;
            pictureBox2.BackColor = Color.MidnightBlue;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Resources.BgMenu1;
            pictureBox2.BackColor = Color.MidnightBlue;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InfoDisplay inf = new InfoDisplay("Aqua MP3 Player", "Change song directory!");
            inf.BringToFront();
            inf.ShowDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                playList = Directory.GetFiles(folderBrowserDialog1.SelectedPath).Where(s => s.Contains(".mp3") || s.Contains(".wav") || s.Contains(".flac") || s.Contains(".m4a")).ToList();

                selectedSong = playList[0];
                player = new NAudio.Wave.AudioFileReader(selectedSong);
            }
            else {                 MessageDisplay msg = new MessageDisplay("Aqua MP3 Player", "No folder selected.");
                msg.BringToFront();
                msg.ShowDialog();
            }


        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.White;
            pictureBox1.Image = Resources.BgBt1;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt1;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgDefault;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt1;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.White;
            pictureBox1.Image = Resources.BgBt2;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt2;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgDefault;
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt2;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.White;
            pictureBox1.Image = Resources.BgBt3;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt3;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgDefault;
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt3;
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.White;
            pictureBox1.Image = Resources.BgBt4;

        }

        private void label4_MouseHover(object sender, EventArgs e)
        {

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt4;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgDefault;
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Black;
            pictureBox1.Image = Resources.BgBt4;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            repeat = !repeat;
            if (repeat)
            {
                label7.Text = "RPT ON";

            }
            else
            {
                label7.Text = "RPT OFF";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentSong--;
            if (currentSong < 0)
            {
                currentSong = playList.Count - 1;
            }


            currentSong--;
            label6.Text = Path.GetFileName(playList[currentSong]);
            label8.Text = currentSong.ToString();
            // song
            output.Stop();
            output.Dispose();
            selectedSong = playList[currentSong];
            player.Dispose();
            player = new NAudio.Wave.AudioFileReader(selectedSong);

            if (output == null || output.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
            {

                output.Init(player);
                output.Play();
            }
            else
            {
                output.Play();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                output.Pause();
            }
            else
            {
                if (output == null || output.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
                {
                    output.Init(player);
                }
                output.Play();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            player.CurrentTime = TimeSpan.Zero;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            currentSong++;
            if (currentSong >= playList.Count)
            {
                currentSong = 0;
            }


            label6.Text = Path.GetFileName(playList[currentSong]);
            label8.Text = currentSong.ToString();
            // song
            output.Stop();
            output.Dispose();
            player.Dispose();
            selectedSong = playList[currentSong];
            player = new NAudio.Wave.AudioFileReader(selectedSong);

            if (output == null || output.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
            {

                output.Init(player);
                output.Play();
            }
            else
            {
                output.Play();
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (volume < 2.0f)
            {
                volume += 0.1f;
                player.Volume = volume;

                progressBar1.Value = (int)(volume * 10);
                progressBar1.Visible = true;
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                int a = 0;
                timer.Interval = 1000;
                timer.Tick += (s, ev) =>
                {

                    progressBar1.Visible = false;


                    timer.Stop();

                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (volume > 0.0f)
            {
                volume -= 0.1f;

                player.Volume = volume;
                progressBar1.Value = (int)(volume * 10);
                progressBar1.Visible = true;
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                int a = 0;
                timer.Interval = 1000;
                timer.Tick += (s, ev) =>
                {

                    progressBar1.Visible = false;


                    timer.Stop();

                    timer.Dispose();
                };
                timer.Start();

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            volume = 1.0f;

            player.Volume = volume;
            progressBar1.Value = (int)(volume * 10);
            progressBar1.Visible = true;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            int a = 0;
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {

                progressBar1.Visible = false;


                timer.Stop();

                timer.Dispose();
            };
            timer.Start();

        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Resources.VolDown;
            pictureBox3.Image = Resources.VolumeDown;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Resources.VolDown2;
            pictureBox3.Image = Resources.VolumeDown;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Resources.VolDown2;
            pictureBox3.Image = Resources.Volume;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Resources.VolDown2;
            pictureBox3.Image = Resources.VolumeDown;
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = Resources.VolUp;
            pictureBox3.Image = Resources.VolumeUp;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Resources.VolUp2;
            pictureBox3.Image = Resources.VolumeUp;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Resources.VolUp2;
            pictureBox3.Image = Resources.Volume;
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = Resources.VolUp2;
            pictureBox3.Image = Resources.VolumeUp;
        }
    }

}
