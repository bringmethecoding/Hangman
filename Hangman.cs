using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Hangman
    {
        private string word;
        private char[] maskedWord;
        public Hangman(string word)
        {
            this.word = word;
            maskedWord = new string('_', word.Length).ToCharArray();
        }

        private char guessedLetter;
        public char GuessedLetter
        {
            get => guessedLetter; 
            set => guessedLetter = value;
        }

        public bool IsLetterInWord()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (guessedLetter.Equals(word[i])) {  return true; }
            }

            numberOfIncorrectGuesses++;
            return false;
        }

        private const int guesses = 8;
        private int numberOfIncorrectGuesses = 0;

        public bool IsGameFinished()
        {
            if (numberOfIncorrectGuesses >= guesses) { return true; }

            if (IsWordGuessed()) { return true; }

            return false;
        }

        public bool IsWordGuessed()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (maskedWord[i] == '_') { return false; }
            }

            return true;
        }

        public void UncoverLetters()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(guessedLetter))
                {
                    maskedWord[i] = guessedLetter;
                }    
            }
        }

        public void GetMaskedWord()
        {
            Console.WriteLine(maskedWord);
        }
    }
}
