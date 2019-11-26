using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public static class ListOfIntExtensions
    {
        public static bool ContainsAllZeros(this List<int> listOfInt)
        {
            foreach(int integer in listOfInt)
            {
                if(integer != 0 )
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsNegativeValues(this List<int> listOfInt)
        {
            foreach(int integer in listOfInt)
            {
                if(integer < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IntegersOutOfRange(this List<int> listOfInt, int upperBound)
        {
            foreach(int integer in listOfInt)
            {
                if(integer > upperBound)
                {
                    return true;
                }
            }
            return false;
        }
    }
}