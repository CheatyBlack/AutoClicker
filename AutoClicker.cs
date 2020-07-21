using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cheaty_AutoClicker
{
    public partial class AutoClicker : Form
    {
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0016;
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int GetAsyncKeyState(int key);
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private int toggle;
        private Random rnd;

        public AutoClicker()
        {
            this.rnd = new Random();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                int maxValue = checked((int)Math.Round(unchecked(1000.0 / (double)this.bunifuVTrackbar1.Value + (double)this.bunifuVTrackbar1.Value * 0.2)));
                int minValue = checked((int)Math.Round(unchecked(1000.0 / (double)this.bunifuVTrackbar2.Value + (double)this.bunifuVTrackbar2.Value * 0.48)));

                this.timer1.Interval = this.rnd.Next(maxValue, minValue);

                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checked { ++this.toggle; }
            if (this.toggle == 1)
            {
                this.timer1.Start();
                this.button1.Text = "ON";
            }
            else
            {
                this.button1.Text = "OFF";
                this.timer1.Stop();
                this.toggle = 0;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuVTrackbar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = bunifuVTrackbar2.Value.ToString();
        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = bunifuVTrackbar1.Value.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void AutoClicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
