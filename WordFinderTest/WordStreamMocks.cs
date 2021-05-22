using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderTest
{
    public static class WordStreamMocks
    {
        public static List<string> NotFoundWordStream = new List<string>() { "fire", "watter" };

        public static List<string> ThreeWordsOnceWordStream_Param = new List<string>() { "chill", "cold", "snow", "wind" };
        public static List<string> ThreeWordsOnceWordStream_Resp = new List<string>() { "wind", "cold", "chill" };

        public static List<string> ThreeWordsOnceWordStreamReverse_Param = new List<string>() { "llihc", "dloc", "wons", "dniw" };
        public static List<string> ThreeWordsOnceWordStreamReverse_Resp = new List<string>() { "dniw", "dloc", "llihc" };

        public static List<string> TwoWordsOnceOneTwiceWordStream_Param = new List<string>() { "chill", "cold", "snow", "wind" };
        public static List<string> TwoWordsOnceOneTwiceWordStream_Resp = new List<string>() { "chill", "wind", "cold" };
    }
}
