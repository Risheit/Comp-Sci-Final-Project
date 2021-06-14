using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    public partial class Memory : Form
    {
        Card[,] cards;       // Jagged array of cards in the game
        Random random;        // random number generator

        /// <summary>
        /// Constructor
        /// </summary>
        public Memory()
        {
            InitializeComponent(); // Initialize design components

            random = new Random(); // Seed the random number generator

            cards = new Card[5, 13]; 
            // Initialize first array of two cards as jokers
            cards[0, 0] = new Card(0, CardSuit.joker, "joker1", false, true);
            cards[0, 1] = new Card(0, CardSuit.joker, "joker2", false, true);
            // Initialize number and face cards with the name being suit + number
            for (int i = 1; i <= 4; i++) // Suits
                for (int j = 1; j <= 13; j++) // Numbers
                    cards[i, j - 1] = new Card(j, (CardSuit)i, Enum.GetName(typeof(CardSuit), i) + j, false, true);

            DrawInitialCards(); // Set initial cards
        }
        
        /// <summary>
        /// Draws the initial matrix of cards using a random unused card in each position
        /// </summary>
        private void DrawInitialCards()
        {
            int x, y;                   // Spot in pixels that the new card will be drawn to
            int numberUsed;             // The number of cards that have already been randomly selected
            Card[] usedCards;           // Array of cards that have already been randomly selected
            Card cardToValidate;        // The card to be validated
            int randomSuit;             // A randomly selected suit
            int randomNumber;           // A randomly selected number

            // Initialize variables
            x = 5;
            y = 30;
            numberUsed = 0;
            usedCards = new Card[52];

            // Draw 51 cards on screen randomly in matrix
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    // Pick random card until a card that has not already been drawn is picked
                    randomSuit = random.Next(0, 5);
                    randomNumber = randomSuit == 0 ? random.Next(0, 2) : random.Next(0, 13); // Use only 0-1 as numbers is joker is suit

                    cardToValidate = cards[randomSuit, randomNumber];
                    for (int k = 0; k < numberUsed; k++)
                    {
                        if (cardToValidate == usedCards[k]) // Check if card has been used
                        {
                            k = 0; // Reset validation

                            // Get new cards
                            randomSuit = random.Next(0, 5);
                            randomNumber = randomSuit == 0 ? random.Next(0, 2) : random.Next(0, 13);
                            cardToValidate = cards[randomSuit, randomNumber]; // Get new cards
                        }
                    }

                    // Draw card
                    cardToValidate.DrawCard(x, y, this);

                    // Adjust variables
                    if (numberUsed < 52)
                        usedCards[numberUsed] = cardToValidate;
                    numberUsed++;
                    x += Card.cardWidth + 5;
                }

                // Move to next row
                x = 5;
                y += Card.cardHeight + 5;
            }

            // Draw first card in the matrix because it doesn't do it automatically
            // Pick random card until a card that has not already been drawn is picked
            randomSuit = random.Next(0, 5);
            randomNumber = randomSuit == 0 ? random.Next(0, 2) : random.Next(0, 13); // Use only 0-1 as numbers is joker is suit

            cardToValidate = cards[randomSuit, randomNumber];
            for (int k = 0; k < numberUsed; k++)
            {
                if (cardToValidate == usedCards[k]) // Check if card has been used
                {
                    k = 0; // Reset validation

                    // Get new cards
                    randomSuit = random.Next(0, 5);
                    randomNumber = randomSuit == 0 ? random.Next(0, 2) : random.Next(0, 13);
                    cardToValidate = cards[randomSuit, randomNumber]; // Get new cards
                }
            }

            // Draw card
            cardToValidate.DrawCard(5, 30, this);

        }
    }
}
