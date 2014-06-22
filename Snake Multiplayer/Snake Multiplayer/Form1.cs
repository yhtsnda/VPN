﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Media;

namespace Snake_Multiplayer
{
    public partial class Form1 : Form
    {
        SoundPlayer choose = new SoundPlayer("D:/Flashdisk/up-down");
        public Form1()
        {
            InitializeComponent();
            toolStripProgressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            toolStripProgressBar1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value += 1;
            toolStripStatusLabel2.Text = toolStripProgressBar1.Value + "%";
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                timer1.Enabled = false;
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Text = "Complete";
                this.Hide();
                Process.Start("Console Snake.exe","1").WaitForExit();
                this.Show();                
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Start the game";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "See How to Play snake";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "See the credit of the snake multiplayer";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
            form2.FormClosed+=new FormClosedEventHandler(muncul);
        }

        private void muncul(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
