using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        bool playAgain;

        do
        {
            int magicNumber = random.Next(1, 101);
            int guess, attempts = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;
                Console.WriteLine(guess < magicNumber ? "Higher" : guess > magicNumber ? "Lower" : $"You guessed it in {attempts} attempts!");
            } while (guess != magicNumber);

            Console.Write("Play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower() == "yes";
        } while (playAgain);
    }
}
