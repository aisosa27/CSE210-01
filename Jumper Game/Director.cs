namespace jumper.game
{
    public class Director
    {
        private Guesses guesses;
        private bool isPlaying;
        private Word word;
        private TerminalService terminalService;
      
        private char userGuess;

        public Director()
        {
            guesses = new Guesses();
            isPlaying = true;
            word = new Word();
            terminalService = new TerminalService();
            userGuess = ' ';
        }

        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        private void GetInputs()
        {
            userGuess = terminalService.getUserGuess();
        }

        private void DoUpdates()
        {
            bool localCorrect = word.IsCorrect(userGuess);
            if(localCorrect == false)
            {
                guesses.countWrongGuesses();
            }
            if(guesses.getWrongGuesses() == 4)
            {
                Console.WriteLine($"Game Over, the correct word is {word.getCorrectWord()}");

                isPlaying = false;
            }
            if(word.isGamewon())
            {
                Console.WriteLine("You Win!");
                
                isPlaying = false;
            }   
        }
        private void DoOutputs()
        {
            foreach (char c in word.getcurrentWord())
            {
                Console.Write(c );
                Console.Write(" ");
            }
            Console.WriteLine(" ");

            terminalService.displayJumper(guesses.getWrongGuesses());
        }

    }
}