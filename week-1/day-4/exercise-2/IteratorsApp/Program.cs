    namespace IteratorsApp
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var fibonacci = FibonacciSequence().Take(10);
                foreach (int number in fibonacci)
                {
                    Console.WriteLine(number);
                }
            }
            // https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
            public static IEnumerable<int> FibonacciSequence()
            {
                //throw new NotImplementedException();
                int x = 0;
                int y = 1;
                int temp;
                for (int i = 0; ; i++)
                {
                    if (i == 0) yield return i;
                    if (i == 1) yield return i;
                    temp = y;
                    y = x + y;
                    x = temp;
                    yield return y;
                }
            }
        }
    }