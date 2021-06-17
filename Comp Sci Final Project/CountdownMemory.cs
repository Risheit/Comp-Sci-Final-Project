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
    public partial class CountdownMemory : Form
    {
        readonly Card[,] cards;     // Matrix of cards in the game
        readonly Random random;     // Random number generator
        CountdownTimer timer;       // Timer to display
        Card firstFlippedCard;      // The card that was previously flipped 
        int points;                 // The amount of points the user has gotten
        

        /// <summary>
        /// Constructor
        /// </summary>
        public CountdownMemory()
        {
            // Initialize components
            InitializeComponent(); 
            random = new Random(); 
            firstFlippedCard = null; // No card previously flipped
            timer = new CountdownTimer(4, "Starting in");

            points = 0;

            cards = new Card[4, 13]; // Initialize matrix 
            // Initialize number and face cards with the name being suit + number
            for (int i = 1; i <= 4; i++) // Suits
                for (int j = 1; j <= 13; j++) // Numbers
                {
                    cards[i - 1, j - 1] = new Card(j, (CardSuit)i, Enum.GetName(typeof(CardSuit), i) + j, false);
                }
            SetAllCardClickEvents(true); // Activate card click events

            // Draw components
            DrawInitialCards();
            
            // Adjust form and form size
            HeaderBar.Size = new Size(ClientSize.Width - timer.Size.Width - 30, 22);

            timer.DrawTimer(Size.Width - timer.Size.Width - 50, 0, this);

        }

        /// <summary>
        /// Draws the initial matrix of cards using a random unused card in each position
        /// </summary>
        private void DrawInitialCards()
        {
            int x, y;               // Spot in pixels that the new card will be drawn to
            int numberUsed;         // The number of cards that have already been randomly selected
            Card[] usedCards;       // Array of cards that have already been randomly selected
            Card card;              // The card to be validated

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
                    // Draw card
                    card = PickValidCard(numberUsed, usedCards);
                    card.DrawCard(x, y, this);

                    // Adjust variables
                    if (numberUsed < 52)
                        usedCards[numberUsed] = card;
                    numberUsed++;
                    x += Card.cardWidth + 5;
                }

                // Move to next row
                x = 5;
                y += Card.cardHeight + 5;
            }

            // Draw first card in the matrix because it doesn't do it automatically
            card = PickValidCard(numberUsed, usedCards);
            card.DrawCard(5, 30, this);
        }

        /// <summary>
        /// Picks a random card that hasn't yet been drawn to the screen from the given array
        /// </summary>
        /// <param name="numberDrawn">The number of drawn cards</param>
        /// <param name="drawnCards">The cards that have already been drawn</param>
        /// <returns>The validate card to draw</returns>
        private Card PickValidCard(int numberDrawn, Card[] drawnCards)
        {
            int randomSuit;         // A randomly selected suit
            int randomNumber;       // A randomly selected number
            Card card;              // The valid card to be returned
                                    
            // Pick random card 
            randomSuit = random.Next(0, 4);
            randomNumber = random.Next(0, 13); // Use only 0-1 as numbers is joker is suit
            card = cards[randomSuit, randomNumber]; 
            // Validate the card
            for (int k = 0; k < numberDrawn; k++)
                if (card == drawnCards[k]) // Pick new cards if the picked card has already been drawn
                {
                    k = 0; // Reset validation

                    // Randomly select a new card
                    randomSuit = random.Next(0, 4);
                    randomNumber = random.Next(0, 13);
                    card = cards[randomSuit, randomNumber];
                }

            return card;
        }

        /// <summary>
        /// Checks if a flipped card is a match with the card clicked before this, if it exists. 
        /// If it does, then it removes both cards and assigns points.
        /// </summary>
        /// <param name="sender">Sending objects</param>
        /// <param name="e">Event details</param>
        private async void CheckCardMatch(object sender, EventArgs e)
        {
            PictureBox cardImage;               // The card image of the card being flipped
            (int row, int column) index;        // The matrix index (row, column) of the card flipped

            // Get index of card
            cardImage = (PictureBox)sender;
            index = FindCardMatrixIndex(cardImage.Name);

            // If this is the first card being flipped, save it and end the function
            if (firstFlippedCard == null) 
            {
                // While flipped, prevent card events for this card
                cards[index.row, index.column].CardImage.Click -= CheckCardMatch;
                cards[index.row, index.column].IsFlipOnClick = false;

                firstFlippedCard = cards[index.row, index.column];
                return;
            }

            // End function if the flipped card is identical to the first card
            if (cards[index.row, index.column] == firstFlippedCard)
                return;

            // Delay checking card match and interaction with cards
            SetAllCardClickEvents(false);
            await Task.Delay(700);
            // If cards match, remove both and award points to player
            if (cards[index.row, index.column].IsMatch(firstFlippedCard))    
            {
                firstFlippedCard.CardImage.Visible = false;
                cards[index.row, index.column].CardImage.Visible = false;

                AwardPoints();
            }
            else // If cards don't match, flip both of them to their back at the same time
            {
                await Task.WhenAll(firstFlippedCard.FlipCard(), cards[index.row, index.column].FlipCard());
            }

            SetAllCardClickEvents(true); // Reactivate flipping
            firstFlippedCard = null; // Reset the first flipped card
        }

        /// <summary>
        /// Looks at the player's statistics before awarding points as needed
        /// </summary>
        private void AwardPoints()
        {
            // Increase points
            points += 100;

            // Repaint header to reflect change in points
            PointsDisplay.Text = "Points: " + points;
        }

        /// <summary>
        /// Loops through the cards array to try and find the index (row, column) value of a card in the card array that
        /// matches the given name of a card
        /// </summary>
        /// <param name="name">The name to search the matrix for</param>
        /// <returns>the row and column index values if the name is found, otherwise (-1, -1)</returns>
        private (int,int) FindCardMatrixIndex(string name)
        {
            // Look for a match of the string in the cards arr   
            for (int row = 0; row < 4; row++)
                for (int column = 0; column < 13; column++)
                    if (cards[row, column].CardImage.Name == name)
                        return (row, column);
            return (-1, -1);
        }

        /// <summary>
        /// Loops through the cards array and sets all cards to either have card click events (e.x. flipping or card checking)
        /// or not depending on the given state
        /// </summary>
        /// <param name="state">true if cards have card events, false otherwise</param>
        private void SetAllCardClickEvents(bool state)
        {
            foreach (Card card in cards)
                if (state)
                {
                    card.CardImage.MouseClick += CheckCardMatch;
                    card.IsFlipOnClick = true;
                }
                else
                {
                    card.CardImage.MouseClick -= CheckCardMatch;
                    card.IsFlipOnClick = false;
                }
        }
    }
}
