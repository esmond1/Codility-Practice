using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(int N)
	{
		// Implement your solution here
		// D = a valid factor of N
		// therefore N/D(aka M) is also a valid factor of N
		// for every D there is an N/D
		// the sqrt of N is the middle point between the first half of this pair (D) and the second half (N/D)
		// if sqrt of N = a whole integer we can add it as a factor (if N/sqrt N == 0)

		double sqrtN = Math.Sqrt(N); // stores the value of sqrt N -> using double as  sqrt N may not always be a whole integer
		int factorCount = 0; // tracks the number of valid factors

		for (int potentialFactor = 1; potentialFactor <= sqrtN; potentialFactor++)
		{ // starting from 1 because 0 will cause errors and 0 can't be a factor of a number anyway
			if (N % potentialFactor == 0)
			{
				int pairedFactor = N / potentialFactor; // corresponding factor aka N/D
				if (potentialFactor == pairedFactor)
				{ // check for perfect square
					factorCount += 1; // we only increment once
				}
				else
				{
					factorCount += 2; // if not a perfect square (eg. 2 and 12) we add both the potential factor and paired so +2
				}
			}

		}
		return factorCount;
	}
}