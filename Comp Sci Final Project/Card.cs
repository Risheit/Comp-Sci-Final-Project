// Card - This class contains all the info about a card and functions to modify them.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_Sci_Final_Project
{
    class Card
    {

        public PictureBox CardImage { get; private set; }      // The image for this card (readonly)

        public int Number { get; }      // This card's number (readonly property)
        public Suit Suit { get; }       // This card's suit (readonly property)
        private bool isFrontFacing;     // Whether the front image is viewable or not
        public bool IsFrontFacing       // Whether the front image is viewable or not (public property)
        { 
            get => isFrontFacing;
            set
            {
                // Change the image on the card depending on if it's front facing or not
                CardImage.Image = value ? Properties.Resources.Placeholder_card_front : Properties.Resources.Placeholder_card_back;
                isFrontFacing = value; // Change value of field
            }
        }                          


        /// <summary>
        /// Constructor that initializes class variables
        /// </summary>
        /// <param name="number">This card's number</param>
        /// <param name="suit">This card's suit</param>
        /// <param name="name">This card's name</param>
        /// <param name="isFrontFacing">(Default false) Whether this card's front is viewable or not</param>
        public Card(int number, Suit suit, string name, bool isFrontFacing = false)
        {
            // Call constructor and initialize card image
            CardImage = new PictureBox
            {
                // Initialize image
                Location = new Point(0, 0),
                Name = name + "Back",
                Size = new Size(56, 87),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                TabIndex = 0,
                TabStop = false
            };

            // Initialize fields
            Number = number;
            Suit = suit;
            IsFrontFacing = isFrontFacing; // Pick which image to show 
        }

        /// <summary>
        /// Draws a picturebox of the card image with upper left point at a given point
        /// </summary>
        /// <param name="x">The card's x position in pixels</param>
        /// <param name="y">The card's y position in pixels</param>
        /// <param name="form">The form being written to (usually the 'this' keyword)</param>
        public void DrawCard(int x, int y, Form form)
        {
            // Set the location for the card images
            CardImage.Location = new Point(x, y);

            // Change card image to depending on what side the card is displaying
            if (IsFrontFacing) // Front side being displayed
                CardImage.Image = Properties.Resources.Placeholder_card_front;
            else // Back side beind displayed
                CardImage.Image = Properties.Resources.Placeholder_card_back;

            // Draw card
            form.Controls.Add(CardImage);
        }

        /// <summary>
        /// Flips a card from backside to front side, or vice-versa
        /// </summary>
        /// <param name="form">The form being written to (usually the 'this' keyword)</param>
        public async void FlipCard(Form form)
        {
            const int MillisecondsDelay = 2600;       // How long to delay moving to next frame of flip animation

            /* Local functions */
            // Returns the value of the current card width adjusted by a given amount
            int AdjustWidth(int width)
            {
                return CardImage.Size.Width + width;
            }
            // Returns the value of the current card's x position adjusted by a given amount
            int AdjustXPos(int x)
            {
                return CardImage.Location.X + x;
            }

            // Flip the Card and switch the image on it
            CardImage.Size = new Size(AdjustWidth(-20), CardImage.Size.Height); // Decrease width by 20
            CardImage.Location = new Point(AdjustXPos(10), CardImage.Location.Y); // Move card to the right by 10
            await Task.Delay(MillisecondsDelay); // Delay next animation step
          
            CardImage.Size = new Size(AdjustWidth(-20), CardImage.Size.Height);
            CardImage.Location = new Point(AdjustXPos(10), CardImage.Location.Y);
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(0, CardImage.Location.Y); // Decrease width to 0
            IsFrontFacing = !IsFrontFacing; // Flip Card Image
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(AdjustWidth(6), CardImage.Size.Height);
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(AdjustWidth(20), CardImage.Size.Height); // Increase width by 20
            CardImage.Location = new Point(AdjustXPos(-10), CardImage.Location.Y); // Move card to the left by 10
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(AdjustWidth(20), CardImage.Size.Height);
            CardImage.Location = new Point(AdjustXPos(-10), CardImage.Location.Y);
        }
    }
}
