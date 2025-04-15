namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Player 1: ");
            string playerOne = Console.ReadLine();
            Console.Write("Player 2: ");
            string playerTwo = Console.ReadLine();

            Console.Write($"{playerOne}, choose a word: ");
            string word = Console.ReadLine();
            Console.Clear();

            Hangman hangman = new Hangman(word);

            do
            {
                Console.WriteLine($"Incorrect guesses: {hangman.GetIncorrectGuessCount()}/{hangman.GetGuesses()}");
                Console.Write("Letters guessed: ");
                char[] guessedLetters = hangman.GetUsedLetters();
                for (int i = 0; i < 26; i++)
                {
                    if (guessedLetters[i] == '1')
                    {
                        Console.Write((char)(i + 97));
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();

                hangman.GetMaskedWord();
                string input;
                do
                {
                    Console.Write($"{playerTwo}, guess a letter: ");
                    input = Console.ReadLine().ToLower();
                } while (input.Length != 1 || !Char.IsLetter(input[0]) || hangman.WasLetterGuessed(input[0]));
                hangman.GuessedLetter = input[0];

                if (hangman.IsLetterInWord())
                {
                    hangman.UncoverLetters();
                }

                if (!hangman.IsGameFinished()) 
                {
                    Console.Clear();
                }

            } while (!hangman.IsGameFinished());

            if (hangman.IsWordGuessed())
            {
                Console.WriteLine($"\nYou won, {playerTwo}!");
            }
            else
            {
                Console.WriteLine($"\nYou lost, {playerTwo}");
            }
        }
    }
}
