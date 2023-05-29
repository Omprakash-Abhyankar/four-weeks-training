namespace StackApp
{
    internal class Program
    {
        private class Stack
        {
            public int value;

            public Stack(int value)
            {
                this.value = value;
            }
        }

        static void Main(string[] args)
        {
            //ICustomStack<int> intStack = new CustomStack<int>();
            //intStack.Push(1);
            //intStack.Push(2);
            //intStack.Push(3);
            //Console.WriteLine(intStack.Pop()); // Output: 3
            //Console.WriteLine(intStack.Pop()); // Output: 2
            //Console.WriteLine(intStack.IsEmpty()); // Output: False


            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Pop());



            CustomStack<string> stack2 = new CustomStack<string>();
            stack2.Push("Om");
            stack2.Push("saurabh");
            stack2.Push("nailesh");
            stack2.Push("Swarn");

            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.IsEmpty());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.IsEmpty());



            CustomStack<Stack> stack3 = new CustomStack<Stack>();
            stack3.Push(new Stack(1));
            stack3.Push(new Stack(2));
            stack3.Push(new Stack(3));
            stack3.Push(new Stack(4));
            stack3.Push(new Stack(5));
            stack3.Push(new Stack(6));



            Console.WriteLine(stack3.Pop());
            Console.WriteLine(stack3.Pop());
            Console.WriteLine(stack3.IsEmpty());
            Console.WriteLine(stack3.Pop());
            Console.WriteLine(stack3.Pop());
            Console.WriteLine(stack3.IsEmpty());


            Console.ReadLine();
        }
    }

    public class CustomStack<T>
    {
        private List<T> list;
        private int size;

        public CustomStack()
        {
            list = new List<T>();
            size = 0;
        }

        public void Push(T item)
        {
            list.Add(item);
            size++;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            T value = list[size - 1];
            list.RemoveAt(size - 1);
            size--;
            return value;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

    }
}
