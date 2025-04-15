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
            this.word = word.ToLower();
            maskedWord = new string('_', word.Length).ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ') 
                { 
                    maskedWord[i] = '-';
                }
            }
        }

        private char guessedLetter;
        public char GuessedLetter
        {
            get => guessedLetter; 
            set => guessedLetter = Char.ToLower(value);
        }

        public bool IsLetterInWord()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (guessedLetter.Equals(word[i])) {  return true; }
            }

            incorrectGuessCount++;
            return false;
        }

        public char[] usedLetters = new string('0', 26).ToCharArray();

        public bool WasLetterGuessed(char input)
        {
            // input is put through ToLower()
            int letter = input - 97;

            if (usedLetters[letter] == '1') { return true; }

            usedLetters[letter] = '1';
            return false;
        }

        private const int guesses = 8;
        private int incorrectGuessCount = 0;

        public bool IsGameFinished()
        {
            if (incorrectGuessCount >= guesses) { return true; }

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

        public int GetIncorrectGuessCount() => incorrectGuessCount;

        public int GetGuesses() => guesses;

        public char[] GetUsedLetters() => usedLetters;
    }
}
