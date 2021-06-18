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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            // Set control locations
            Images.Location = new Point(label1.Width + 20, Title2.Height + 50);
            this.Width = label1.Width + Images.Width + 50;
        }
    }
}
