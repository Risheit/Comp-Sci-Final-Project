// Contains a timer and a label to display the timer

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    class CountdownTimer
    {
        private int totalSeconds;                   // The total seconds
        private string labelText;                   // The text displayed on the label about what this timer is
        private Label label;                        // Label to display time left
        public Size Size { get; private set; }      // The size of the container (readonly property
        public Timer Timer { get; }                 // Timer to countdown
        private bool visible;                       // The visibility of the timer and its label
        public bool Visible                         // The visibility of the timer and its label (public property)
        {
            get => visible;
            set
            {
                label.Visible = value; // Set the visibility of the label
                visible = value;
            }
        }

        /// <summary>
        /// Constructor that initializes the timer and sets its countdown amount
        /// </summary>
        /// <param name="seconds">The number of seconds the timer runs for</param>
        /// <param name="text">The text to display for this label before a colon and 
        /// the time remaining</param>
        public CountdownTimer(int seconds, string text)
        {
            // Initialize
            totalSeconds = seconds;
            labelText = text;
            Timer = new Timer()
            {
                Enabled = true,
                Interval = 1000 // Ticks down every 1 second   
            };
            label = new Label()
            {
                AutoSize = true,
                Name = "timerLabel",
                Text = $"{labelText}: {seconds}"
            };
            Size = label.Size;

            Timer.Tick += Timer_Tick; // Add tick event
        }

        /// <summary>
        /// Event that occurs every timer tick
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event details</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Count down
            if (totalSeconds > 0) // Calculation
            {
                // Decrease timer by a second until it has stopped
                totalSeconds--;
                int seconds = totalSeconds;
                label.Text = $"{labelText}: {seconds}"; // Change displayed time
            }
            else // When timer is 0, it stops
            {
                // tells the timer to stop
                Timer.Stop();
            }
        }

        /// <summary>
        /// Draws a label of the timer with upper left point at a given point
        /// </summary>
        /// <param name="x">The card's x position in pixels</param>
        /// <param name="y">The card's y position in pixels</param>
        /// <param name="form">The form being written to (usually the 'this' keyword)</param>
        public void DrawTimer(int x, int y, Form form)
        {
            // Set the location for the label
            label.Location = new System.Drawing.Point(x, y);
            label.BringToFront();

            // Draw label
            form.Controls.Add(label);
            // Anchor timer to spot on form
            label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
        }

        /// <summary>
        /// Creates a loop and returns true when the timer ends. Recommened use in an async function.
        /// </summary>
        /// <returns><see langword="true"/> when timer ends</returns>
        public bool GetTimerEnd()
        {
            while (Timer.Enabled) // Loop until timer stops
            { continue; }
            return true;
        }

    }
}