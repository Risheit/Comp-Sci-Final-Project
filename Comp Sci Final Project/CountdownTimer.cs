// Contains a timer and a label to display the timer

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    class CountdownTimer
    {
        private int secondsLeft;                    // The seconds left before the timer stops
        private readonly string labelText;          // The text displayed on the label about this timer 
        private readonly Label label;               // Label to display time left
        public Timer Timer { get; }                 // Timer to countdown
        public Size Size { get; private set; }      // The size of the container (readonly property)

        private bool visible;       // The visibility of the timer and its label
        public bool Visible         // The visibility of the timer and its label (public property)
        {
            get => visible; // Get field
            set
            {
                label.Visible = value; // Set the visibility of the label
                visible = value; // Change value of field
            }
        }

        /// <summary>
        /// Initializes a new CountdownTimer object.
        /// </summary>
        /// <param name="seconds">The number of seconds the timer runs for.</param>
        /// <param name="text">The text to display on this timer before a colon and 
        /// the time remaining (text: 30 s).</param>
        public CountdownTimer(int seconds, string text)
        {
            // Initialize
            secondsLeft = seconds;
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
                Text = $"{labelText}: {seconds} s"
            };
            Size = label.Size;

            Timer.Tick += Timer_Tick; // Add tick event
        }

        /// <summary>
        /// Decreases the timer and checks if it needs to stop every tick.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Count down
            if (secondsLeft > 0)
            {
                // Decrease timer by a second until it has stopped
                secondsLeft--;
                label.Text = $"{labelText}: {secondsLeft} s"; // Change displayed time
            }
            else // When timer is 0, it stops
            {
                Timer.Stop();
            }
        }

        /// <summary>
        /// Draws a label of the timer with the upper left point at a given point.
        /// </summary>
        /// <param name="x">The card's x position in pixels.</param>
        /// <param name="y">The card's y position in pixels.</param>
        /// <param name="form">The form being written to (usually the 'this' keyword).</param>
        public void DrawTimer(int x, int y, Form form)
        {
            // Set the location for the label
            label.Location = new Point(x, y);
            label.BringToFront();

            // Draw label
            form.Controls.Add(label);
            // Anchor timer to spot on form
            label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
        }
        
        /// <summary>
        /// Removes the timer from the form.
        /// </summary>
        /// <param name="form">The form being written to (usually the 'this' keyword).</param>
        public void RemoveTimer(Form form)
        {
            // Remove label
            form.Controls.Remove(label);
        }

        /// <summary>
        /// Creates a loop and returns true when the timer ends. Recommened use is in an async function.
        /// </summary>
        /// <returns><see langword="true"/> when timer ends.</returns>
        public bool GetTimerEnd()
        {
            while (Timer.Enabled) // Loop until timer stops
            { continue; }
            return true;
        }
    }
}