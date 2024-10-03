using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        string letter = grade >= 90 ? "A" : grade >= 80 ? "B" : grade >= 70 ? "C" : grade >= 60 ? "D" : "F";
        Console.WriteLine($"Your letter grade is: {letter}");
        Console.WriteLine(grade >= 70 ? "Congratulations! You passed." : "Keep trying next time.");
    }
}
