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
		// pair of integers = slice (P,Q)
		// 0 <=P <= Q < N
		// sum of slice = A[P] + A[P+1] +... A[Q]
		// eg. sum of slice (1,3) = A[1] + A[1+1] + A[3] = (2) + (-6) + (4) = 0
		// eg. sum of slice (0,4) = A[0] + A[0+1] + A[0+2] + A[0+3] + A[4] = 3
		// eg. sum of slice (2,2) = A[2] = -6
		// eg. sum of slice (3,4) = A[3] + A[3+1] = 4

		// want to return max sum of any slice
		// variable that records maxSlice (temp set to A[0] lowest pssible value)
		// variable that records currentSliceSum (temp set to A[0] lowest pssible value)
		// want the slice(P) to begin at first element and we continue to add another element until end of slice (Q) 
		// for every addition to the current slice sum we update the variable
		// if current slice sum = -ve then reset to 0
		// check if its > maxSlice and if yes then update
		// if no then continue to add elements 

		int currentSliceSum = A[0];
		int maxSlice = A[0];

		for (int i = 1; i < A.Length; i++)
		{
			// add current index to currentslicesum
			currentSliceSum = Math.Max(A[i], currentSliceSum + A[i]); // A[i] = start a new slice from current index // cSS + A[i] = continue to extend the current slice adding A[i]
			maxSlice = Math.Max(maxSlice, currentSliceSum);
		}

		return maxSlice;
	}
}