using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Sci_Final_Project
{
    enum CardSuit       // Enum for card suits
    {
        joker1 = 0,
        joker2,
        hearts = 3,
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Prevents blurriness for high-DPI screens
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Memory());
        }
    }
}
