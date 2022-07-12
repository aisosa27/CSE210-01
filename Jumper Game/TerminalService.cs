using System;

namespace jumper.game
{
    public class TerminalService
    {
        public TerminalService()
        {

        }

        public string ReadLetter(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void displayJumper(int wrongGuesses)
        {
            if (wrongGuesses == 0)
            {
                Console.WriteLine(" _____ ");
            }
            if (wrongGuesses <= 1)
            {
                Console.WriteLine("/_____\\ ");
            }
            if (wrongGuesses <= 2)
            {
                Console.WriteLine("\\     /");
            }
            if (wrongGuesses <= 3)
            {
                Console.WriteLine(" \\   / ");
            }
            if (wrongGuesses < 4)
            {
                Console.WriteLine("   O   ");
            }
            else
            {
                Console.WriteLine("   x   ");
            } 
            Console.WriteLine("  /|\\  ");
            Console.WriteLine("  / \\  ");
            Console.WriteLine("");
            Console.WriteLine("^^^^^^^");
        }
        public char getUserGuess()
        {
            char userGuess;
            Console.WriteLine("Guess a letter[a-z]: ");
            userGuess = Console.ReadLine()[0];
            return userGuess;
        }
    }
}