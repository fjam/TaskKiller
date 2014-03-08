using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Close_progs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.MarqueeAnimationSpeed = 0;
            label2.Text = "Stopped";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.Text = "Please Enter a Process";
            }
            else
            {
                label2.Text = "Running";
                progressBar1.MarqueeAnimationSpeed = 30;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Stopped";
            progressBar1.Value = 0;
            progressBar1.MarqueeAnimationSpeed = 0;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();

            foreach (Process pr in prs)
            {
                if (pr.ProcessName == textBox1.Text)
                {
                    pr.Kill();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
