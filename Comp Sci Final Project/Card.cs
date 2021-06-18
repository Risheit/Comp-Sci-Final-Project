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
        public static int cardWidth = 112 / 2;       // The card's default width
        public static int cardHeight = 174 / 2;      // The card's default height

        public PictureBox CardImage { get; private set; }       // The image for this card (private property)
        public int Number { get; }                              // This card's number (readonly property)
        public CardSuit Suit { get; }                           // This card's suit (readonly property)
        public CardColour Colour { get; }                       // This card's colour (readonly property)

        private bool isFrontFacing;     // Whether the front image is viewable or not
        public bool IsFrontFacing       // Whether the front image is viewable or not (public property)
        {
            get => isFrontFacing; // Get field
            set // Change the image on the card depending on if it's front facing or not
            {
                CardImage.Image = value ? Program.GetCardImage(Suit, Number) : Properties.Resources.red_back;
                isFrontFacing = value; // Change value of field
            }
        }

        private bool isFlipOnClick;     // Whether this card flips on a click or not
        public bool IsFlipOnClick       // Whether this card flips on a click or not (public property)
        {
            get => isFlipOnClick; // Get field
            set // Change whether the card can be flipped on click or not
            {
                if (value) // Add flip card on click if true
                    CardImage.MouseClick += FlipCard;
                else // Remove flip card on click if false
                    CardImage.MouseClick -= FlipCard;

                isFlipOnClick = value; // Change value of field
            }
        }

        /// <summary>
        /// Constructor that initializes class variables
        /// </summary>
        /// <param name="number">This card's number</param>
        /// <param name="suit">This card's suit</param>
        /// <param name="name">This card's name</param>
        /// <param name="isFrontFacing">(Default false) Whether this card's front is viewable or not</param>
        /// <param name="isFlipOnClick">(Default false) Whether this card flips on click or not</param>
        public Card(int number, CardSuit suit, string name, bool isFrontFacing = false, bool isFlipOnClick = false)
        {
            // Call constructor and initialize card image
            CardImage = new PictureBox
            {
                // Initialize image
                Location = new Point(),
                Name = name,
                Size = new Size(cardWidth, cardHeight),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabIndex = 0,
                TabStop = false, // Can't be selected with tab
            };

            // Initialize fields and properties
            Number = number;
            Suit = suit;
            // Set card colour to red if the suit is hearts or diamonds, set it to black if it isn't
            Colour = suit == CardSuit.hearts || suit == CardSuit.diamonds ? CardColour.red : CardColour.black;
            IsFrontFacing = isFrontFacing;  
            IsFlipOnClick = isFlipOnClick; 
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

            // Draw card
            form.Controls.Add(CardImage);
        }

        /// <summary>
        /// Removes the card image from a given form
        /// </summary>
        /// <param name="form">The form being written to (usually the 'this' keyword)</param>
        public void RemoveCard(Form form)
        {
            form.Controls.Remove(CardImage);
        }

        /// <summary>
        /// Flips a card from backside to front side, or vice-versa
        /// </summary>
        public async Task FlipCard()
        {
            const int MillisecondsDelay = 26;       // How long to delay moving to next frame of flip animation

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
            CardImage.Size = new Size(AdjustWidth(-20), cardHeight); // Decrease width by 20
            CardImage.Location = new Point(AdjustXPos(10), CardImage.Location.Y); // Move card to the right by 10
            await Task.Delay(MillisecondsDelay); // Delay next animation step
          
            CardImage.Size = new Size(AdjustWidth(-20), cardHeight);
            CardImage.Location = new Point(AdjustXPos(10), CardImage.Location.Y);
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(0, cardHeight); // Decrease width to 0
            IsFrontFacing = !IsFrontFacing; // Flip Card Image
            
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(AdjustWidth(6), cardHeight);
            await Task.Delay(MillisecondsDelay);
            
            CardImage.Size = new Size(AdjustWidth(20), cardHeight); // Increase width by 20
            CardImage.Location = new Point(AdjustXPos(-10), CardImage.Location.Y); // Move card to the left by 10
            await Task.Delay(MillisecondsDelay);

            CardImage.Size = new Size(cardWidth, cardHeight); // Reset size
            CardImage.Location = new Point(AdjustXPos(-10), CardImage.Location.Y); // Reset location
        }

        /// <summary>
        /// Overload that calls the regular FlipCard() function as an event so it can be attached to a 
        /// mouse click through code.
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event Details</param>
        private async void FlipCard(object sender, MouseEventArgs e)
        {
            await FlipCard();
        }

        /// <summary>
        /// Checks if this card matches up with another card (the number and colour of both cards are the same)
        /// </summary>
        /// <param name="other">The other card to match</param>
        /// <returns><see langword="true"/> if cards match, and <see langword="false"/> otherwise.</returns>
        public bool IsMatch(Card other)
        {
            if (this.Number == other.Number && this.Colour == other.Colour)
                return true;
            else
                return false;
        }
    }
}
