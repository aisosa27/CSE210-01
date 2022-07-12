using System;
namespace jumper.game
{
    public class Word
    {

        private List<string> wordsList;
        private List<char> currentWord;
        private string correctWord;

        public Word()
        {
            this.wordsList = new List<string>();
            this.currentWord = new List<char>();
            this.correctWord = "";

            string filename = "words.txt";

            wordsList = File.ReadLines(filename).ToList();
            getRandomWord();

        }
        public List<char> getcurrentWord()
        {
            return currentWord;
        }
        public string getCorrectWord()
        {
            return correctWord;
        }
        private void getRandomWord()
        {
            Random random = new Random();
            this.correctWord = wordsList[random.Next(0, wordsList.Count)];

            foreach(char  c in this.correctWord)
            {
                currentWord.Add('_');
            }
        }
        public bool isGamewon()
        {
            for(int i=0; i < currentWord.Count; i++)
            {
                if (currentWord[i] != correctWord[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsCorrect(char userGuess)
        {
            bool correct = false;
            for(int i=0; i< correctWord.Length; i++)
            {
                if (userGuess == correctWord[i] && currentWord[i]=='_')
                {
                    currentWord[i] = userGuess;
                    correct = true;
                }
            }
            return correct;
        }

    }
}