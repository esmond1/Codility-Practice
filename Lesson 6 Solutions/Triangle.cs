using System;

class Solution
{
	public int solution(int[] A)
	{
		// Sort the array in ascending order
		Array.Sort(A);

		// Check for triangular triplets by iterating through the array
		for (int i = 0; i < A.Length - 2; i++)
		{
			if (A[i] + A[i + 1] > A[i + 2])
			{
				return 1; // A valid triangle can be formed
			}
		}

		// Return 0 if no triangular triplet exists
		return 0;
	}
}
