//Завдання 2
//Write a program to remove duplicates from a sorted int[]. Think about time and
//space complexity.
namespace DublicateIntChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 1, 56, 4, 4, 56 };
            Console.WriteLine("Input:");
            foreach (int i in array)
                Console.Write($"{i} ");

            Console.WriteLine();
            HashSet<int> ints = new HashSet<int>(array);
            array = ints.OrderBy(n=>n).ToArray();

            Console.WriteLine("\n Output:");
            foreach (int i in array)
                Console.Write($"{i} ");
        }
    }
}
