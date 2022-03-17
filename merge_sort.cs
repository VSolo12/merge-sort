using System;
using System.Collections.Generic;

namespace Merge_Sort
{
    class Merge_Sort
    {
        private static List<int> mergeSort( List<int> unsortedList )
        {
            if ( unsortedList.Count <= 1 )
                return unsortedList;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int midpoint = unsortedList.Count / 2;

            for ( int index = 0; index < midpoint; index++ )
            {
                left.Add( unsortedList[index] );
            }

            for ( int index = midpoint; index < unsortedList.Count; index++ )
            {
                right.Add( unsortedList[index] );
            }

            left = mergeSort( left );
            right = mergeSort( right );

            return merge( left, right );
        }

        private static List<int> merge( List<int> left, List<int> right )
        {
            List<int> result = new List<int>();

            while ( left.Count > 0 || right.Count > 0 )
            {
                if ( left.Count > 0 && right.Count > 0 )
                {
                    if( left.First() <= right.First() )
                    {
                        result.Add( left.First() );
                        left.Remove( left.First() );
                    }
                    else
                    {
                        result.Add( right.First() );
                        right.Remove( right.First() );
                    }
                }
                else if( left.Count > 0 )
                {
                    result.Add( left.First() );
                    left.Remove( left.First() );
                }
                else if( right.Count > 0 )
                {
                    result.Add( right.First() );
                     right.Remove( right.First() );
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>();
            List<int> sorted;

            Random random = new Random();

            Console.WriteLine("Original array elements: ");
            for( int index = 0; index < 15; index++ )
            {
                unsorted.Add(random.Next( 0, 100 ));
                Console.Write(unsorted[index] + " ");
            }
            Console.WriteLine();

            sorted = mergeSort(unsorted);

            Console.WriteLine("Sorted array elements: ");
            foreach(int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
        }
    }
}