namespace FibonacciNumberFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Write number bigger than 0");
                int number;
                int.TryParse(Console.ReadLine(), out number);
                if (number < 0) throw new ArgumentException("Number must be bigger than 0");

                Console.WriteLine($"Recursive: {FibonacciRecursive(number)}");

                Console.WriteLine($"Iterative: {FibonacciRecursive(number)}");
            }
        }

        //Рекурсивний метод:
        //Часова складність: 𝑂(2^𝑛)
        //Просторова складність: 𝑂(𝑛)
        private static int FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }


        //Ітеративний метод:
        //Часова складність: 𝑂(𝑛)
        //Просторова складність: 𝑂(1)
        private static int FibonacciIterative(int n)
        {
            if (n <= 1)
                return n;

            int a = 1;
            int b = 2;

            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}
