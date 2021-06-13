using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    enum CardSuit       // Enum for card suits
    {
        joker = 0,
        hearts,
        diamonds,
        clubs,
        spades
    }
    enum CardColour     // Enum for card colours
    {
        red = 0, 
        black
    }

    static class Program
    {
        private static Dictionary<string, System.Drawing.Bitmap> cardDictionary; // Dictionary for card images

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Prevents blurriness for high-DPI screens


            // Initialize dictionary
            cardDictionary = new Dictionary<string, System.Drawing.Bitmap>
            {
                // Add images to dictionary
                { CardSuit.hearts.ToString() + 1, Properties.Resources.Placeholder_card_front },
                { CardSuit.hearts.ToString() + 2, Properties.Resources.Placeholder_card_front }
            };


            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Memory());

        }

        /// <summary>
        /// Uses given card and suit to look up the corresponding card front image
        /// </summary>
        /// <param name="suit">The suit of the card to look up</param>
        /// <param name="number">The number of the card to look up</param>
        /// <returns>Card image corresponding to the given card in Bitmap form</returns>
        public static System.Drawing.Bitmap GetCardImage(CardSuit suit, int number)
        {
            System.Drawing.Bitmap cardImage;        // The card image to return

            cardDictionary.TryGetValue(suit.ToString() + number, out cardImage);

            // Write error if lookup fails
            Debug.WriteLineIf(cardImage == default(System.Drawing.Bitmap), "Lookup failed");

            // Return value looked up
            return cardImage;
        }
    }
}
