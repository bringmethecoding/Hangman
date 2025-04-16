namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Player 1: ");
            string playerOne = Console.ReadLine();
            string currentPlayer = playerOne;
            Console.Write("Player 2: ");
            string playerTwo = Console.ReadLine();
            string currentGuesser = playerTwo;

            do
            {
                Console.Write($"{currentPlayer}, choose a word: ");
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

                    Console.WriteLine(hangman.GetMaskedWord());
                    string input;
                    do
                    {
                        Console.Write($"{currentGuesser}, guess a letter: ");
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
                    Console.WriteLine($"\nYou won, {currentGuesser}!");
                }
                else
                {
                    Console.WriteLine($"\nYou lost, {currentGuesser}");
                }
            } while (playAgain(ref currentPlayer, ref currentGuesser));
        }

        static bool playAgain(ref string player, ref string guesser)
        {
            Console.WriteLine("\nDo you want to continue? y/n");
            string input;
            do
            {
                input = Console.ReadLine().ToLower();
            } while (input.Length != 1 || (input[0] != 'y' && input[0] != 'n'));

            if (input[0] == 'y') 
            {
                string temp = player;
                player = guesser;
                guesser = temp;

                Console.Clear();

                return true; 
            }

            return false;
        }
    }
}
