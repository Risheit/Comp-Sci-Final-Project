﻿// Class holding timer information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_Sci_Final_Project
{
    class Timer
    {

    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//// this is a countdown timer for only the seconds the min is converted in to seconds (max min = 5= 300sec)
//namespace memory_card_game
//{
//    public partial class Form1 : Form
//    {
//        private int total_sec;// the total seconds 
//        public Form1()
//        {
//            InitializeComponent();
//        }
//        // form
//        private void Form1_Load(object sender, EventArgs e)
//        {
//            // loops all the numbers that can be selected
//            for (int i = 1; i < 300; i++)
//            {
//                this.ComboBox2.Items.Add(i.ToString());
//            }
//        }
//        // start button
//        private void button1_Click(object sender, EventArgs e)
//        {
//            //// disable button1 this button
//            this.button1.Enabled = false;
//            // enable button2
//            this.button2.Enabled = true;
//            // the second that is selected is the seconds
//            int seconds = int.Parse(this.ComboBox2.SelectedItem.ToString()); ;
//            // enable the timer when click start
//            this.timer1.Enabled = true;
//            // total seconds
//            total_sec = seconds;
//        }

//        // button 2
//        private void button2_Click(object sender, EventArgs e)
//        {
//            // disable button 2
//            this.button2.Enabled = false;
//            // enable button1
//            this.button1.Enabled = true;
//            //
//            int seconds = int.Parse(this.ComboBox2.SelectedItem.ToString());
//        }
//        // the timer
//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            // count down
//            // calculation
//            if (total_sec > 0)
//            {
//                // if total_sec > 0 subtract 1
//                total_sec--;
//                int seconds = total_sec;
//                this.label3.Text = seconds.ToString();
//            }
//            // else when timme is zero the timer stops
//            else
//            {
//                // tells the timer to stop
//                this.timer1.Stop();
//                // prints time up when timer is 0 
//                MessageBox.Show("Times Up!!!!");

//            }
//        }
//    }
//}