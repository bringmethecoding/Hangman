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
            Console.WriteLine('\n');

            Hangman hangman = new Hangman(word);

            do
            {
                Console.WriteLine($"Incorrect guesses: {hangman.GetIncorrectGuessCount()}/{hangman.GetGuesses()}");

                hangman.GetMaskedWord();
                string input;
                do
                {
                    Console.Write($"{playerTwo}, guess a letter: ");
                    input = Console.ReadLine();
                } while (input.Length != 1 || !Char.IsLetter(input[0]));
                hangman.GuessedLetter = input[0];


                if (hangman.IsLetterInWord())
                {
                    hangman.UncoverLetters();
                }

                Console.WriteLine('\n');

            } while (!hangman.IsGameFinished());

            if (hangman.IsWordGuessed())
            {
                Console.WriteLine($"You won, {playerTwo}!");
            }
            else
            {
                Console.WriteLine($"You lost, {playerTwo}");
            }
        }
    }
}
