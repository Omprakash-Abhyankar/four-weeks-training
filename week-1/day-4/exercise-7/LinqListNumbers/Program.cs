using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of integers
        List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        // Use LINQ to find all even numbers
        var evenNumbers = from number in numbers
                          where number % 2 == 0
                          select number;

        // Use LINQ to find all numbers greater than a specific value
        int threshold = 20;
        var greaterNumbers = from number in numbers
                             where number > threshold
                             select number;

        // Use LINQ to calculate the sum of all numbers
        int sum = numbers.Sum();

        // Use LINQ to calculate the average of all numbers
        double average = numbers.Average();

        // Use LINQ to find the minimum and maximum values in the list
        int min = numbers.Min();
        int max = numbers.Max();

        // Print the results to the console
        Console.WriteLine("Even numbers: {0}", string.Join(", ", evenNumbers));
        Console.WriteLine("Numbers greater than {0}: {1}", threshold, string.Join(", ", greaterNumbers));
        Console.WriteLine("Sum of all numbers: {0}", sum);
        Console.WriteLine("Average of all numbers: {0:F2}", average);
        Console.WriteLine("Minimum value: {0}", min);
        Console.WriteLine("Maximum value: {0}", max);
    }
}
