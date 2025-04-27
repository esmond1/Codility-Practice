using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(int[] A)
	{
		// Implement your solution here
		// triplet (X,Y,Z) = double slice
		// sum of double slice = (value of X+1 up to and including Y - 1) + (value of Y+1 up to and including Z-1)
		// return max sum of a double slice

		// variable for maxDoubleSliceSum
		// split array into 2 subarrays
		// maxEndingHere = max sum of the left slice ending at index (i-1)
		// maxStartingHere = max sum of right slice starting at index (i+1)
		// 3 loops:
		// loop 1 checks for max sum of slices (left) from X+1 to Y-1
		// loop 2 checks for max sum of slices (right) from Y+1 to Z-1
		// loop 3 checks for best total sum of slices (left+right) using value of Y to be iterated over (excluding Y as a middle point)

		int N = A.Length;

		int[] maxEndingHere = new int[N];
		int[] maxStartingHere = new int[N];

		//loop 1 

		for (int i = 1; i < N - 1; i++)
		{ // i = 1 because X<Y so X can be a 0 or earlier
			maxEndingHere[i] = Math.Max(0, maxEndingHere[i - 1] + A[i]); // if we can extend the current left slice ending at i-1 without being less than 0 continue
																		 // otherwise reset and start again from that index
		}

		//loop 2

		for (int i = N - 2; i > 0; i--)
		{ // i = N-2 because Z<N and i > 0 so there's always a valid left slice
			maxStartingHere[i] = Math.Max(0, maxStartingHere[i + 1] + A[i]); // if we can extend the current right slice starting from i+1 without being less than 0 than continue
																			 // otherwise reset and start again from that index
		}

		int maxDoubleSliceSum = 0;

		//loop 3

		for (int Y = 1; Y < N - 1; Y++)
		{ // Y = 1 giving room for a valid left slice and Y < N-1 giving room for a valid left slice

			int sum = (maxEndingHere[Y - 1]) + (maxStartingHere[Y + 1]); // calculating sum of best possible left slice ending at y-1 + best possible right starting at y+1 (excludes Y)
			maxDoubleSliceSum = Math.Max(maxDoubleSliceSum, sum); // each time we check against current maxDSS and update if sum>maxDSS
		}

		return maxDoubleSliceSum;
	}
}