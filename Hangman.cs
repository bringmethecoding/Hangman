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
        public Hangman(string word)
        {
            this.word = word;
            char[] maskedWord = new string('_', word.Length).ToCharArray();
        }

        private string letter;
        public string Letter { get; set; }

        public bool IsLetterInWord()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (letter.Equals(word[i])) {  return true; }
            }

            return false;
        }

        private const int guesses = 8;
        private int numberOfGuesses = 0;

        public bool IsGameFinished()
        {
            if (numberOfGuesses >= guesses) { return true; }

            if (IsWordGuessed()) { return true; }

            return false;
        }

        public bool IsWordGuessed()
        {
            return false;
        }
    }
}
