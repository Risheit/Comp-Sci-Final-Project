// The form that allows choosing of which game of Memory to play

using System;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    public partial class StartPage : Form
    {
        /// <summary>
        /// Initializes a new StartPage form.
        /// </summary>
        public StartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Quits the application.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Starts a round of timed memory.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void CountdownMemory(object sender, EventArgs e)
        {
            Form memory;        // The game of memory to be played

            // Hide this form while the game is running
            Hide(); 
            memory = new CountdownMemory();
            memory.ShowDialog(); // Run game
            Show(); // Return to start screen
        }

        /// <summary>
        /// Starts a round of untimed memory.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void UntimedMemory(object sender, EventArgs e)
        {
            Form memory;        // The game of memory to be played

            // Hide this appliction while the game is running
            Hide();
            memory = new StopwatchMemory();
            memory.ShowDialog(); // Run game
            Show(); // Return to start screen
        }

        /// <summary>
        /// Opens the help form.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void OpenHelp(object sender, EventArgs e)
        {
            Form help;        // The help menu to be loaded

            // Prevent using this form while the game is running
            SuspendLayout();
            help = new Help();
            help.ShowDialog(); // Run game
            ResumeLayout(); // Return to start screen
        }
    }
}
