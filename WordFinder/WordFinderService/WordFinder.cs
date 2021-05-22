using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordFinder.WordFinderService
{
    public class WordFinder : WordFinderRectangularMatrixBase
    {
        public WordFinder(IEnumerable<string> matrix): base(matrix)
        {
        }

        public override IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream == null || !wordstream.Any())
                throw new ArgumentException("The word stream cannot be null or empty.", "wordstream");

            // Initializing the results list
            var resultList = new List<string>();

            // Initalizing a count tracker wich helps to insert the words in the right position into the result list
            var countTracker = new List<int>(){0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach (string word in wordstream)
            {
                // Prevent process a word more than once
                if (wordCounter.ContainsKey(word)) continue;

                var count = 0;

                // Can search horizontally
                if (word.Length <= matrixLength)
                {
                    count += FindWordRepetitionInRows(word);
                }

                // Can search vertically
                if (word.Length <= matrixHeight)
                {
                    count += FindWordRepetitionInCols(word);
                }

                // Register the word and it amount of occurences
                wordCounter[word] = count;

                // I there are no occurrences must not be included in the result array
                if (count <= 0) continue;

                // Check if the word is one of the 10 most repeated
                if (count < countTracker[9]) continue;

                // Check if the word is the most repeated until now
                if (count >= countTracker[0])
                {
                    resultList.Insert(0, word);
                    countTracker.Insert(0, count);
                    continue;
                }

                // Find the right position of the word into the top 10 positions
                int pos = FindPosition(countTracker, count);

                // Add validation just in case
                if(pos > -1)
                {
                    resultList.Insert(pos, word);
                    countTracker.Insert(pos, count);
                }
            }

            // return only the first 10 items
            return resultList.Take(10);
        }

        private int FindPosition(List<int> list, int item)
        {
            for(int i = 1; i < 9; i++)
            {
                if (list[i] <= item) return i;
            }

            return -1;
        }

        private int FindWordRepetitionInRows(string word)
        {
            int count = 0;

            for(int i = 0; i < matrixHeight; i++)
            {
                // Count in each rows
                count += CountWordOccurrencesInRow(i, word);
            }

            return count;
        }

        private int FindWordRepetitionInCols(string word)
        {
            int count = 0;

            for (int i = 0; i < matrixLength; i++)
            {
                // Count in each cols
                count += CountWordOccurrencesInCol(i, word);
            }

            return count;
        }
    }
}
