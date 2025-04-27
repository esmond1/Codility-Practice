using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(int[] A)
	{
		// Implement your solution here
		// peak = element larger than its neighbours
		// eg. A(P-1) < P > A(P+1)
		// eg. 1 < 5 > 3 => 5 is a peak
		// we want to set the max no. flags on peaks
		// if you have K flags => the distance between any two flags must be distance >= K
		// eg. peaks = 1 , 3 , 5 , 10 
		// 4 flags means you can only set a flag on  1 , 5 , 10
		// 3 flags means you can only set a flag on 1 , 5, 10
		// 2 flags means you can set a flag on all flags 1 , 3 ,5 , 10
		// therefore max flags = 3

		// goal = return the max number of flags on the max number of peaks

		// could use a List to record all peaks in A
		// we push every peak to the List
		// element is pushed if -> A(P-1) < P > A(P+1) 
		// next need to see how max num of flags we can use that fulfill the distance >=K
		// using binary search: between low =1 and high = number of peaks
		// for each mid point -> mid = low + high / 2
		// then try to place mid flags on peaks
		// if it does fit distance >= K we then --> increase low (larger number of mid)
		// if it doesn't fit distance >= K --> lower high (smaller number of mid)
		// continue until low > high 
		// resulting flagcount will be the last valid value of mid
		// return flagcount

		List<int> peaks = new List<int>();

		for (int i = 1; i < A.Length - 1; i++)
		{
			if (A[i - 1] < A[i] && A[i] > A[i + 1])
			{
				peaks.Add(i); // if it follows the A(P-1) < P > A(P+1) rule we can add the index to our list of peaks
			}
		}

		if (peaks.Count == 0) return 0;

		// setting up binary search params
		int low = 1; // Minimum number of flags (start with at least 1)
		int high = peaks.Count; // Maximum number of flags = the number of peaks
		int result = 0;

		while (low <= high)
		{ // while the lowest number of flags is less than or equal to the highest number
			int mid = (low + high) / 2; // calcing the midpoint aka the number of flags we are trying to place for our peaks
			int usedFlags = 1; // placing the first flag
			int lastFlag = peaks[0];

			for (int i = 1; i < peaks.Count; i++)
			{
				if (peaks[i] - lastFlag >= mid)
				{
					usedFlags++;
					lastFlag = peaks[i];
					if (usedFlags == mid) break;
				}
			}

			if (usedFlags >= mid)
			{
				result = mid;
				low = mid + 1; // try for more flags
			}
			else
			{
				high = mid - 1; // try for less flags
			}
		}
		return result;

	}
}