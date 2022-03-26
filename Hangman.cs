using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_of_the_day
{
    class Hangman
    {
        public string Word { get; }
        public int NumGuesses { get; set; }
        public char[] GameBoard { get; set; }

        public Hangman(string word)
        {
            Word = word.ToLower();
            NumGuesses = 6;

            GameBoard = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                GameBoard[i] = '_';
            }

            PlayGame();
        }

        private bool CheckWon() 
        {
            return string.Join("", GameBoard) == Word;
        }

        private void CheckGuess(char guess)
        {
            bool guessed = false;
            for (int i = 0; i < Word.Length; i++)
            {
                if (guessed = guess == Word[i])
                {
                    GameBoard[i] = guess;
                }
            }

            if (!guessed) NumGuesses--;
        }
        private bool ValidateGuess(string userInput)
        {
            return !(userInput.Length == 0 || userInput[0] == ' ' || userInput[0] > 'z' || userInput[0] < 'a');
        }
        private char GetGuess()
        {
            Console.Write("Guess a Letter: ");
            string userInput = Console.ReadLine().ToLower();

            bool valid = ValidateGuess(userInput);

            if (valid) return userInput[0];
            else Console.WriteLine("You must guess a single letter (A-Z), if you enter a word the first letter will be used"); return GetGuess();
        }
        private void DisplayBoard()
        {
            Console.WriteLine(string.Join(" ", GameBoard));
        }
        private void PlayGame()
        {
            bool gameWon = false;

            while (!gameWon && NumGuesses > 0)
            {
                DisplayBoard();
                CheckGuess(GetGuess());
                gameWon = CheckWon();
                Console.WriteLine();
            }

            DisplayBoard();
            Console.WriteLine(gameWon ? "Yay you won!" : "You ran out of guesses");
        }
    }
}
