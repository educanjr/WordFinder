using System;
using System.Linq;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the matrix!");
            Console.WriteLine("Write comma separated strings to build your matrix:");
            Console.WriteLine("(white spaces will be mantained)");
            var inputMatrix = Console.ReadLine();

            try
            {
                var inputMatrixArr = inputMatrix.Split(",");
                var wordFinder = new WordFinderService.WordFinder(inputMatrixArr);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Write comma separated words to find into the inserted matrix:");
                Console.WriteLine("(white spaces will be mantained)");
                var inputWordStream = Console.ReadLine();

                var wordStream = inputWordStream.Split(",");

                var foundList = wordFinder.Find(wordStream).ToList();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Results orderer by amount of occurences");
                for (int i = 0; i < foundList.Count; i++)
                {
                    Console.WriteLine($"{i+1}- {foundList[i]}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
