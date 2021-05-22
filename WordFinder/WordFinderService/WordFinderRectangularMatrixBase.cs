using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Helpers;

namespace WordFinder.WordFinderService
{
    public abstract class WordFinderRectangularMatrixBase
    {
        protected const int MAX_ROWS = 64;
        protected const int MAX_COLS = 64;

        protected readonly char[][] matrix;
        protected readonly int matrixLength;
        protected readonly int matrixHeight;

        protected readonly Dictionary<string, int> wordCounter = new Dictionary<string, int>();

        public WordFinderRectangularMatrixBase(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
                throw new ArgumentException("The matrix cannot be null or empty.", "matrix");

            // Ensure max ammount of rows
            if (matrix.Count() > MAX_ROWS)
            {
                matrix = matrix.Take(MAX_ROWS);
            }

            // Ensure max amount of cols and standarize row length
            var minCharacters = matrix.Min(i => i.Length);
            minCharacters = minCharacters > MAX_COLS ? MAX_COLS : minCharacters;

            // Convert matrix into bidimentional char array and ensure the same length for all matrix's rows
            this.matrix = matrix.Select(i => i.Substring(0, minCharacters).ToCharArray()).ToArray();

            this.matrixLength = minCharacters;
            this.matrixHeight = matrix.Count();
        }

        public abstract IEnumerable<string> Find(IEnumerable<string> wordstream);

        protected int CountWordOccurrencesInRow(int rowIndex, string word)
        {
            if (rowIndex > matrixHeight || string.IsNullOrEmpty(word) || word.Length > matrixLength) return 0;

            // Build row word string
            string rowWord = new string(matrix[rowIndex]);

            // Build reverse row word string
            string rowWordReverse = new string(matrix[rowIndex].ToArray().Reverse().ToArray());

            int count = 0;

            try
            {
                // Count forward (left to right)
                count += rowWord.CountOcurrences(word);

                // Count backward (right to forward)
                count += rowWordReverse.CountOcurrences(word);
            } 
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            return count;
        }

        protected int CountWordOccurrencesInCol(int colIndex, string word)
        {
            if (colIndex > matrixLength || string.IsNullOrEmpty(word) || word.Length > matrixHeight) return 0;

            // Build column word and reverse column word strings
            string colWord = string.Empty;
            string colWordReverse = string.Empty;
            for (int i = 0, k = matrixHeight - 1; i < matrixHeight && k >= 0; i++, k--)
            {
                colWord += matrix[i][colIndex];
                colWordReverse += matrix[k][colIndex];
            }

            int count = 0;
            try
            {
                // Count forward (up to down)
                count += colWord.CountOcurrences(word);

                // Count backward (down to up)
                count += colWordReverse.CountOcurrences(word);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            return count;
        }
    }
}
