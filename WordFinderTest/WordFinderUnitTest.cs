using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WordFinderTest.Helpers;
using Xunit.Sdk;

namespace WordFinderTest
{
    [TestClass]
    public class WordFinderUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WordFinder_CreateWithNullMatrix_Throw()
        {
            new WordFinder.WordFinderService.WordFinder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WordFinder_CreateWithEmptyMatrix_Throw()
        {
            new WordFinder.WordFinderService.WordFinder(new List<string>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WordFinder_FindWithNullWordStream_Throw()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.CreationValidMatrix);
            wordFinder.Find(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WordFinder_FindWithEmptyWordStream_Throw()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.CreationValidMatrix);
            wordFinder.Find(new List<string>());
        }

        [TestMethod]
        public void WordFinder_FindNoOcurencesWordStream_EmptyList()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.ValidMatrix5x5);
            var result = wordFinder.Find(WordStreamMocks.NotFoundWordStream);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void WordFinder_FindThreeWordsWordStream_OnceOccurenceSuccess()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.ValidMatrix5x5);
            var result = wordFinder.Find(WordStreamMocks.ThreeWordsOnceWordStream_Param);

            var resultList = result.ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(resultList.CompareStringList(WordStreamMocks.ThreeWordsOnceWordStream_Resp));
        }

        [TestMethod]
        public void WordFinder_FindThreeWordsReverseWordStream_OnceOccurenceSuccess()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.ValidMatrix5x5);
            var result = wordFinder.Find(WordStreamMocks.ThreeWordsOnceWordStreamReverse_Param);

            var resultList = result.ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(resultList.CompareStringList(WordStreamMocks.ThreeWordsOnceWordStreamReverse_Resp));
        }

        [TestMethod]
        public void WordFinder_FindThreeWordsReverseWordStream_Success()
        {
            var wordFinder = new WordFinder.WordFinderService.WordFinder(MatrixMocks.ValidMatrix6x5);
            var result = wordFinder.Find(WordStreamMocks.TwoWordsOnceOneTwiceWordStream_Param);

            var resultList = result.ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(resultList.CompareStringList(WordStreamMocks.TwoWordsOnceOneTwiceWordStream_Resp));
        }
    }
}
