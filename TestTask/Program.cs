//Завдання 1
//Group the unique words of same length in a given sentence, sort the groups in
//increasing order and display the groups, the word count and the words of that
//length.
using System.Text.RegularExpressions;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write sentence:");
            string input = "“The “C# Professional” course includes the topics I discuss in my CLR via C# book and teaches how the CLR works thereby showing you how to develop applications and reusable components for the .NET Framework.”";//  Console.ReadLine();
            string sentences =  string.IsNullOrWhiteSpace(input) ? throw new Exception("Sentence can not be empty") : input;

            sentences =  Regex.Replace(sentences, @"[“”]|(?<=\w)\.(?=\s|”|$)", string.Empty);
            var checkedSentence = sentences.ToLower().Split(' ').Distinct().GroupBy(word => word.Length).OrderBy(g=>g.Key).ToList();

            foreach(var groupOfSentences in checkedSentence)
            {
                Console.WriteLine($"Words of length {groupOfSentences.Key}, Count: {groupOfSentences.Count()}");
                foreach(var sentence in groupOfSentences )
                Console.WriteLine(sentence);
            }
            Console.ReadLine();
        }
    }
}
