// This program runs a game of Memory.
// June 18, 2021
// David Odubor-Okojie, Risheit Munshi

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    enum CardSuit       // Enum for card suits
    {
        hearts,
        diamonds,
        clubs,
        spades
    }
    enum CardColour     // Enum for card colours
    {
        red, 
        black
    }

    static class Program
    {
        private static Dictionary<string, System.Drawing.Bitmap> imageDictionary;       // Dictionary for card images

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Prevents blurriness for high-DPI screens


            // Initialize dictionary with card images
            imageDictionary = new Dictionary<string, System.Drawing.Bitmap>
            {
                //// Add images to dictionary
                //{ CardSuit.joker.ToString() + 0, Properties.Resources.Joker},

                { CardSuit.hearts.ToString() + 1, Properties.Resources.AH},
                { CardSuit.hearts.ToString() + 2, Properties.Resources._2H},
                { CardSuit.hearts.ToString() + 3, Properties.Resources._3H},
                { CardSuit.hearts.ToString() + 4, Properties.Resources._4H},
                { CardSuit.hearts.ToString() + 5, Properties.Resources._5H},
                { CardSuit.hearts.ToString() + 6, Properties.Resources._6H},
                { CardSuit.hearts.ToString() + 7, Properties.Resources._7H},
                { CardSuit.hearts.ToString() + 8, Properties.Resources._8H},
                { CardSuit.hearts.ToString() + 9, Properties.Resources._9H},
                { CardSuit.hearts.ToString() + 10, Properties.Resources._10H},
                { CardSuit.hearts.ToString() + 11, Properties.Resources.JH},
                { CardSuit.hearts.ToString() + 12, Properties.Resources.QH},
                { CardSuit.hearts.ToString() + 13, Properties.Resources.KH},
                
                { CardSuit.diamonds.ToString() + 1, Properties.Resources.AD},
                { CardSuit.diamonds.ToString() + 2, Properties.Resources._2D},
                { CardSuit.diamonds.ToString() + 3, Properties.Resources._3D},
                { CardSuit.diamonds.ToString() + 4, Properties.Resources._4D},
                { CardSuit.diamonds.ToString() + 5, Properties.Resources._5D},
                { CardSuit.diamonds.ToString() + 6, Properties.Resources._6D},
                { CardSuit.diamonds.ToString() + 7, Properties.Resources._7D},
                { CardSuit.diamonds.ToString() + 8, Properties.Resources._8D},
                { CardSuit.diamonds.ToString() + 9, Properties.Resources._9D},
                { CardSuit.diamonds.ToString() + 10, Properties.Resources._10D},
                { CardSuit.diamonds.ToString() + 11, Properties.Resources.JD},
                { CardSuit.diamonds.ToString() + 12, Properties.Resources.QD},
                { CardSuit.diamonds.ToString() + 13, Properties.Resources.KD},
                
                { CardSuit.clubs.ToString() + 1, Properties.Resources.AC},
                { CardSuit.clubs.ToString() + 2, Properties.Resources._2C},
                { CardSuit.clubs.ToString() + 3, Properties.Resources._3C},
                { CardSuit.clubs.ToString() + 4, Properties.Resources._4C},
                { CardSuit.clubs.ToString() + 5, Properties.Resources._5C},
                { CardSuit.clubs.ToString() + 6, Properties.Resources._6C},
                { CardSuit.clubs.ToString() + 7, Properties.Resources._7C},
                { CardSuit.clubs.ToString() + 8, Properties.Resources._8C},
                { CardSuit.clubs.ToString() + 9, Properties.Resources._9C},
                { CardSuit.clubs.ToString() + 10, Properties.Resources._10C},
                { CardSuit.clubs.ToString() + 11, Properties.Resources.JC},
                { CardSuit.clubs.ToString() + 12, Properties.Resources.QC},
                { CardSuit.clubs.ToString() + 13, Properties.Resources.KC},
                
                { CardSuit.spades.ToString() + 1, Properties.Resources.AS},
                { CardSuit.spades.ToString() + 2, Properties.Resources._2S},
                { CardSuit.spades.ToString() + 3, Properties.Resources._3S},
                { CardSuit.spades.ToString() + 4, Properties.Resources._4S},
                { CardSuit.spades.ToString() + 5, Properties.Resources._5S},
                { CardSuit.spades.ToString() + 6, Properties.Resources._6S},
                { CardSuit.spades.ToString() + 7, Properties.Resources._7S},
                { CardSuit.spades.ToString() + 8, Properties.Resources._8S},
                { CardSuit.spades.ToString() + 9, Properties.Resources._9S},
                { CardSuit.spades.ToString() + 10, Properties.Resources._10S},
                { CardSuit.spades.ToString() + 11, Properties.Resources.JS},
                { CardSuit.spades.ToString() + 12, Properties.Resources.QS},
                { CardSuit.spades.ToString() + 13, Properties.Resources.KS},
            };


            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartPage());
        }

        /// <summary>
        /// Uses given card and suit to look up the corresponding card front image.
        /// </summary>
        /// <param name="suit">The suit of the card to look up,</param>
        /// <param name="number">The number of the card to look up.</param>
        /// <returns>Card image corresponding to the given card in Bitmap form.</returns>
        public static System.Drawing.Bitmap GetCardImage(CardSuit suit, int number)
        {
            Bitmap cardImage;        // The card image to return

            imageDictionary.TryGetValue(suit.ToString() + number, out cardImage);

            // Write error if lookup fails
            Debug.WriteLineIf(cardImage == default(Bitmap), "Lookup failed, " + suit.ToString() + number);

            // Return value looked up
            return cardImage;
        }
    }
}
