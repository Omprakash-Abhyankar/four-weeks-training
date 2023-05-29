// C# program to find factorial
// of given number
using System;

class Test
{
    // method to find factorial
    // of given number

    static long factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    /*  public static int factorial(int n)
      {

          if (n == 0)
              return 1;

          return n * factorial(n - 1);
      }*/

    // Driver method
    public static void Main()
    {
        Console.WriteLine("Enter The No. For Calculating Factorial: ");

        // Create a string variable and get user input from the keyboard and store it in the variable
        int n = Convert.ToInt32(Console.ReadLine());
        float Ans = Convert.ToSingle(factorial(n));

        Console.WriteLine("Factorial of "
                        + n + " is " + Ans);
        Console.WriteLine("Press Any Key To Exist");
        Console.ReadKey();
    }
}

// This code is contributed by vt_m
