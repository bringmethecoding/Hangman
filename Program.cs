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

            int playerOneScore = 0;
            int playerTwoScore = 0;

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
                    Console.WriteLine($"\nYou scored, {currentGuesser}!");
                    
                    if (currentGuesser.Equals(playerOne)) { playerOneScore++; }
                    else { playerTwoScore++; }
                }
                else
                {
                    Console.WriteLine($"\n{currentPlayer} scored!");
                    if (currentGuesser.Equals(playerOne)) { playerTwoScore++; }
                    else { playerOneScore++; }
                }

                Console.WriteLine("\nCurrent score:");
                Console.WriteLine($"{playerOne}: {playerOneScore}");
                Console.WriteLine($"{playerTwo}: {playerTwoScore}");

            } while (playAgain(ref currentPlayer, ref currentGuesser));

            Console.Clear();
            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine($"{playerOne} won by {playerOneScore - playerTwoScore} point(s)!");
            }
            else if (playerOneScore < playerTwoScore) 
            {
                Console.WriteLine($"{playerTwo} won by {playerTwoScore - playerOneScore} point(s)!");
            }
            else
            {
                Console.WriteLine($"You tied with {playerOneScore} point(s)!");
            }
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
