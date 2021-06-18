// The form that shows a static help page with application information

using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    public partial class Help : Form
    {
        /// <summary>
        /// Initializes a new Help form.
        /// </summary>
        public Help()
        {
            InitializeComponent();
            // Set control locations
            Images.Location = new Point(label1.Width + 20, Title2.Height + 50);
            this.Width = label1.Width + Images.Width + 50;
            Title2.Select(); // Select title so scroll bar appears at top of form
        }

        /// <summary>
        /// Opens link to the wepage the card images were received from.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void CardImages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://acbl.mybigcommerce.com/52-playing-cards/");
        }

        /// <summary>
        /// Opens link to the wepage the joker image was received from.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void JokerImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://depositphotos.com/vector-images/joker-card.html?qview=6587568");
        }
    }
}
