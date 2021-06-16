using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    public partial class Form1 : Form
    {
        CountdownTimer timer;

        public Form1()
        {
            InitializeComponent();

            timer = new CountdownTimer(4);
            timer.DrawTimer(14, 12, this);
        }
    }
}
