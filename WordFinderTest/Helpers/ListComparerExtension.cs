using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderTest.Helpers
{
    public static class ListComparerExtension
    {
        public static bool CompareStringList<T>(this List<T> list1, List<T> list2)
        {
            if (typeof(T) != typeof(string))
                throw new ArgumentException("The List to compare must be an string List");

            // If one of the list is null, return false
            if ((list1 == null && list2 != null) || (list2 == null && list1 != null))
                return false;

            // If both lists are null, return true, since its same
            else if (list1 == null && list2 == null)
                return true;

            // If count don't match between 2 lists, then return false
            if (list1.Count != list2.Count)
                return false;


            for (var i = 0; i < list1.Count; i++)
            {
                var item1 = list1[i] as string;
                var item2 = list2[i] as string;

                // If one of the elements are not equals return false
                if (item1 != item2)
                    return false;
            }

            // If all the elements are same then return true
            return true;
        }
    }
}
