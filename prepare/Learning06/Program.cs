using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Program!");
        string name = Prompt("Please enter your name: ");
        int num = Convert.ToInt32(Prompt("Please enter your favorite number: "));
        Console.WriteLine($"{name}, the square of your number is {num * num}");
    }

    static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}
