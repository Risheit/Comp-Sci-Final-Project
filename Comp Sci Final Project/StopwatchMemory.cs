// The form that runs an untimed game of Memory

using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    public partial class StopwatchMemory : Form
    {
        private readonly Card[,] cards;                         // Matrix of cards in the game
        private readonly Random random;                         // Random number generator
        private Card firstFlippedCard;                          // The card that was previously flipped 
        private (Label label, Stopwatch timer) stopwatch;       // The stopwatch maintaining time passed

        private int points;                 // The amount of points the user has gotten
        private int pairsMissed;            // The number of unsucessful flips before a match is made
        private int mostPairsMissed;        // The highest number of unsucessful flips before a match is made
        private int totalPairsFlipped;      // The total number of flips made

        /// <summary>
        /// Initializes a new StopwatchMemory form.
        /// </summary>
        public StopwatchMemory()
        {
            // Initialize components
            InitializeComponent(); 
            random = new Random(); 
            firstFlippedCard = null; // No card previously flipped
            stopwatch.timer = new Stopwatch();
            stopwatch.label = new Label()
            {
                Visible = false,
                Location = new Point(HeaderBar.Width, 0),
                AutoSize = true,
                Margin = new System.Windows.Forms.Padding(0),
                Name = "StopwatchLabel",
                Size = new System.Drawing.Size(63, 17),
                Text = "Time Passed: 00:00",
                TabIndex = 0
            };
            Controls.Add(stopwatch.label); // Add the stopwatch to the form

            points = 0;
            pairsMissed = 0;
            mostPairsMissed = 0;
            totalPairsFlipped = 0;

            cards = new Card[4, 13]; // Initialize matrix 
            // Initialize and draw cards 
            for (int suit = 1; suit <= 4; suit++) // Suits
                for (int num = 1; num <= 13; num++) // Numbers
                    cards[suit - 1, num - 1] = new Card(num, (CardSuit)suit, Enum.GetName(typeof(CardSuit), suit) + num, true);
            DrawInitialCards();

            // Resize header bar to fit
            HeaderBar.Size = new Size(ClientSize.Width - 250, 22);
        }

        /// <summary>
        /// Draws the initial matrix of cards using a random unused card in each position.
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
        /// Picks a random card that hasn't yet been drawn to the screen from the given array.
        /// </summary>
        /// <param name="numberDrawn">The number of drawn cards,</param>
        /// <param name="drawnCards">The cards that have already been drawn.</param>
        /// <returns>The validated card to draw.</returns>
        private Card PickValidCard(int numberDrawn, Card[] drawnCards)
        {
            int randomSuit;         // A randomly selected suit
            int randomNumber;       // A randomly selected number
            Card card;              // The valid card to be returned
                                    
            // Pick random card 
            randomSuit = random.Next(0, 4);
            randomNumber = random.Next(0, 13);
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
        /// If it does match, then it removes both cards and assigns points.
        /// </summary>
        /// <param name="sender">Sending objects.</param>
        /// <param name="e">Event details.</param>
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
                _ = PrintMatchDialog(); // Don't stop game while printing dialog
            }
            else // If cards don't match, flip both of them to their back at the same time 
            {
                pairsMissed++; // Increase the number of missed matches
                await Task.WhenAll(firstFlippedCard.FlipCard(), cards[index.row, index.column].FlipCard());
            }

            totalPairsFlipped++; // Increase the total pairs flipped
            // If the amount of pairs missed is a record, save it
            mostPairsMissed = mostPairsMissed < pairsMissed ? pairsMissed : mostPairsMissed; 

            SetAllCardClickEvents(true); // Reactivate flipping
            firstFlippedCard = null; // Reset the first flipped card
        }

        /// <summary>
        /// Prints a message about a successful match to the player.
        /// </summary>
        /// <returns>A task when completed.</returns>
        private async Task PrintMatchDialog()
        {
            Label dialog;       // The dialog that is printed

            // Print starting text in place of stopwatch
            stopwatch.label.Visible = false;
            dialog = new Label()
            {
                AutoSize = true,
                Name = "startingText",
                Location = new Point(HeaderBar.Width, 0),
                BackColor = Color.DarkOliveGreen,
                ForeColor = Color.WhiteSmoke,
                Text = "Successful Match!"
            };
            Controls.Add(dialog);
            await Task.Delay(800);
            // Bring back the stopwatch
            Controls.Remove(dialog); 
            stopwatch.label.Visible = true; 
        }

        /// <summary>
        /// Looks at the player's statistics before awarding points as needed.
        /// </summary>
        private void AwardPoints()
        {
            // Decrease points depending on the pairs missed, preventing any negative points
            points += 100 - (4 * pairsMissed) < 0? 0 : 100 - (4 * pairsMissed);
            pairsMissed = 0; // Reset the missed pairs 

            // Repaint header to reflect change in points
            PointsDisplay.Text = "Points: " + points;
        }

        /// <summary>
        /// Loops through the cards array to try and find the index (row, column) value of a card in the card array that
        /// matches the given name of a card.
        /// </summary>
        /// <param name="name">The name to search the matrix for,</param>
        /// <returns>the row and column index values if the name is found, otherwise (-1, -1).</returns>
        private (int,int) FindCardMatrixIndex(string name)
        {
            // Look for a match of the string in the cards arr   
            for (int row = 0; row < 4; row++)
                for (int column = 0; column < 13; column++)
                    if (cards[row, column].CardImage.Name == name)
                        return (row, column);

            return (-1, -1); // No cards found
        }

        /// <summary>
        /// Loops through the cards array and sets all cards to either have card click events (e.x. flipping or card checking)
        /// or not depending on the given state.
        /// </summary>
        /// <param name="state">true if cards should have card events, false otherwise.</param>
        private void SetAllCardClickEvents(bool state)
        {
            // Loop through each card and adjust click events
            foreach (Card card in cards)
                if (state) // Add
                {
                    card.CardImage.MouseClick += CheckCardMatch;
                    card.IsFlipOnClick = true;
                }
                else // Remove
                {
                    card.CardImage.MouseClick -= CheckCardMatch;
                    card.IsFlipOnClick = false;
                }
        }

        /// <summary>
        /// Starts the game on window load.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private async void UntimedMemory_Load(object sender, EventArgs e)
        {
            Label label;                // Label that prints the starting message to the window

            // Give time for player to get ready 
            await RunStartingPeriod();
            
            // Print starting text for 1 second 
            label = new Label()
            {
                AutoSize = true,
                Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom),
                Name = "startingText",
                Location = new Point(HeaderBar.Width, 0),
                BackColor = Color.DarkOliveGreen,
                Text = "Begin!"
            };
            Controls.Add(label);
            await Task.Delay(1000);
            Controls.Remove(label);

            // Add stopwatch and start it
            stopwatch.label.Visible = true;
            stopwatch.timer.Start();

            // Check for the end of the game and run game over tasks when it occurs
            while (!await Task.Run(() => GetGameEnd()))
            { continue; }
            await RunGameOver();
        }

        /// <summary>
        /// Runs a starting period for 4 seconds to give the player some time to breathe, 
        /// printing a timer at top right of the window to show how long it is.
        /// </summary>
        /// <returns>A task when completed.</returns>
        private async Task RunStartingPeriod()
        {
            CountdownTimer starting;     // Timer during the preperation period

            // Create and draw a timer to show how long the preperation period is
            starting = new CountdownTimer(4, "Starting in");
            starting.DrawTimer(HeaderBar.Width, 0, this);

            SetAllCardClickEvents(false); // Prevent card clicks
            await Task.Run(() => starting.GetTimerEnd()); // Wait for the preperation timer to end

            // Get rid of timer and end starting period
            starting.RemoveTimer(this); 
            SetAllCardClickEvents(true); 
        }

        /// <summary>
        /// Gets the number of matches made (the number of invisible cards / 2).
        /// </summary>
        /// <returns>The number of matches made.</returns>
        private int GetMatchesMade()
        {
            int numberNotVisible;       // The number of cards that aren't visible

            numberNotVisible = 0; // Initialize

            // Loop through cards and check visibility
            foreach (Card c in cards)
                if (!c.CardImage.Visible) // Increase for every not visible card
                    numberNotVisible++;

            return numberNotVisible / 2; // Return the number of pairs of not visible cards
        }

        /// <summary>
        /// Creates a loop and returns true when the game ends. Recommened use in an async function.
        /// </summary>
        /// <returns><see langword="true"/> when game ends.</returns>
        private bool GetGameEnd()
        {
            // Return true when either all cards are matched or time runs out
            while (GetMatchesMade() != 26)
            { continue; }
            return true;
        }

        /// <summary>
        /// Ends the game in a couple seconds and prints statistics.
        /// </summary>
        /// <returns>A task when completed.</returns>
        private async Task RunGameOver()
        {
            Label label;                // Label that prints the ending message to the window

            // End Stopwatch
            stopwatch.timer.Stop();

            // Set statistics
            Statistics.Text =
                $"Time Passed: {Math.Ceiling((double)stopwatch.timer.Elapsed.TotalSeconds)} s \r\n" + 
                $"Points: {points} \r\n" +
                $"Longest Failed Matches in a Row: {mostPairsMissed} \r\n" +
                $"Total Matches Attempted: {totalPairsFlipped} \r\n" +
                $"Total Matches Made: {GetMatchesMade()} \r\n\r\n" +
                $"Close this Window or use the quit button to return to the Start Page. \r\n";
            // Intialize label
            label = new Label()
            {
                AutoSize = true,
                Name = "EndingText",
                Location = new Point(HeaderBar.Width, 0),
                BackColor = Color.Gold,
                Text = "Finished!"
            };

            // Print ending text and remove cards
            SetAllCardClickEvents(false);
            stopwatch.label.Visible = false;
            Controls.Add(label);
            PointsDisplay.Visible = false;
            foreach (Card c in cards)
                c.RemoveCard(this);
            await Task.Delay(1000);
            Controls.Remove(label); // Remove label

            // Have header bar take full top of form
            HeaderBar.Dock = DockStyle.Top;

            // Make statistics and quit button visible
            GameEnd.Visible = true;
            StatisticsHeader.Visible = true;
            Statistics.Visible = true;
            Quit.Visible = true;
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Changes time stopwatch displays every tick.
        /// </summary>
        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event details.</param>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            stopwatch.label.Text = $"Time Passed: {Math.Ceiling((double)stopwatch.timer.Elapsed.TotalSeconds)} s";
        }
    }
}
