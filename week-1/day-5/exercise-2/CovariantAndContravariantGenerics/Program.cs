namespace CovariantAndContravariantGenerics
{
    interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    public class StringToIntProcessor : IProcessor<string, int>
    {
        // Implement Process method
        public int Process(string input)
        {
            return input.Length;
            //throw new NotImplementedException();
        }
    }

    class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
        public string Process(double input)
        {
            // throw new NotImplementedException();
            return input.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrate covariance and contravariance with IProcessor interface


            IProcessor<string, int> processor1 = new StringToIntProcessor();
            // IProcessor<string, object> processor1 = (IProcessor<string, object>)new StringToIntProcessor();

            int result1 = (int)processor1.Process("My Name Is Om");
            Console.WriteLine($"Result 1: {result1}");

            IProcessor<double, object> processor2 = new DoubleToStringProcessor();
            string result2 = (string)processor2.Process(6416);
            Console.WriteLine($"Result 2: {result2}");

        }
    }
}