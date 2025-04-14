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

            Hangman hangman = new Hangman(word);

            do
            {
                hangman.GetMaskedWord();
                Console.Write($"{playerTwo}, guess a letter: ");
                hangman.GuessedLetter = char.Parse(Console.ReadLine());

                if (hangman.IsLetterInWord())
                {
                    hangman.UncoverLetters();
                }

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
