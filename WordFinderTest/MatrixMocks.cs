using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderTest
{
    public static class MatrixMocks
    {
        public static List<string> CreationValidMatrix = new List<string>(){ "col01", "col02" };

        public static List<string> ValidMatrix5x5 = new List<string>(){ "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };

        public static List<string> ValidMatrix6x5 = new List<string>(){ "abcdc", "fgwio", "chill", "pqnsd", "uvdxy", "chill" };
    }
}
