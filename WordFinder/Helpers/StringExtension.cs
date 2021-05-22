using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Helpers
{
    public static class StringExtension
    {
        public static int CountOcurrences(this string baseWord, string toFindWord)
        {
            if (string.IsNullOrEmpty(baseWord))
                throw new ArgumentException("The base word cannot be null or white space", "baseWord");

            if (string.IsNullOrEmpty(toFindWord))
                throw new ArgumentException("The word to find cannot be null or white space", "toFindWord");

            int count = 0, start = 0, startPos = 0;
            int end = baseWord.Length - 1, endPos = end;

            // Count form begining to end and end to begining at same time
            while (startPos < endPos && startPos > -1 )
            {
                endPos = baseWord.LastIndexOf(toFindWord, end);
                startPos = baseWord.IndexOf(toFindWord, start);

                if (startPos == -1) break;

                if (endPos == startPos) count++;

                if (endPos > startPos) count += 2;

                start = startPos + 1;
                end = endPos - 1;
            }

            return count;
        }
    }
}
