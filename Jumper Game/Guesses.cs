using System;

namespace jumper.game
{
    public class Guesses
    {
        private int wrongGuesses;
        public Guesses()
        {
            wrongGuesses = 0;
        }
        public int getWrongGuesses()
        {
            return wrongGuesses;
        }
        public void countWrongGuesses()
        {
            wrongGuesses++;
        }
    }
}