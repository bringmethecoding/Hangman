using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Hangman
    {
        private string word;
        public string Word { get; set; }

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
    }
}
