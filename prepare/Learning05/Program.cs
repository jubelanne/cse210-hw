using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int num;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while ((num = Convert.ToInt32(Console.ReadLine())) != 0)
        {
            numbers.Add(num);
        }

        int sum = 0, max = int.MinValue, smallestPositive = int.MaxValue;
        foreach (int n in numbers)
        {
            sum += n;
            if (n > max) max = n;
            if (n > 0 && n < smallestPositive) smallestPositive = n;
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        if (smallestPositive != int.MaxValue) Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        numbers.ForEach(Console.WriteLine);
    }
}
