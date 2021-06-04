// Card - This class contains all the info about a card and functions to modify them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_Sci_Final_Project
{
    class Card
    {
        public int Number { get; }                                         // This card's number (readonly)
        public Suit Suit { get; }                                          // This card's suit (readonly)
        public bool IsFrontViewable { get; set; }                          // Whether the front image is viewable or not

        public System.Windows.Forms.PictureBox BackCardImage { get; private set; }      // The back image for this card (readonly)
        public System.Windows.Forms.PictureBox FrontCardImage { get; private set; }     // The front image for this card (readonly)

        /// <summary>
        /// Constructor that initializes class variables
        /// </summary>
        /// <param name="number">This card's number</param>
        /// <param name="suit">This card's suit</param>
        /// <param name="name">This card's name</param>
        public Card(int number, Suit suit, string name)
        {
            // Initialize fields
            Number = number;
            Suit = suit;
            IsFrontViewable = false;

            // Call constructors
            BackCardImage = new System.Windows.Forms.PictureBox();
            FrontCardImage = new System.Windows.Forms.PictureBox();

            // Initialize back image
            BackCardImage.Image = Properties.Resources.Placeholder_card_back;
            BackCardImage.Location = new System.Drawing.Point(0, 0);
            BackCardImage.Name = name + "Back";
            BackCardImage.Size = new System.Drawing.Size(56, 87);
            BackCardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackCardImage.TabIndex = 0;
            BackCardImage.TabStop = false;

            // Initalize front image
            FrontCardImage.Image = Properties.Resources.Placeholder_card_front; // TODO: Add selection
            FrontCardImage.Location = new System.Drawing.Point(0, 0);
            FrontCardImage.Name = name + "Front";
            FrontCardImage.Size = new System.Drawing.Size(56, 87);
            FrontCardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            FrontCardImage.TabIndex = 0;
            FrontCardImage.TabStop = false;
        }

        /// <summary>
        /// Draws a picturebox of the card image with upper left point at a given point
        /// </summary>
        /// <param name="x">The card's x position in pixels</param>
        /// <param name="y">The card's y position in pixels</param>
        /// <param name="form">The form being written to (usually the 'this' keyword)</param>
        public void DrawCard(int x, int y, System.Windows.Forms.Form form)
        {
            // Set the location for the card images
            BackCardImage.Location = new System.Drawing.Point(x, y);
            FrontCardImage.Location = new System.Drawing.Point(x, y);

            // Add image to form depending on what side the card is displaying
            if (IsFrontViewable) // Front side being displayed
                form.Controls.Add(FrontCardImage);
            else // Back side beind displayed
                form.Controls.Add(BackCardImage);
        }


    }
}
