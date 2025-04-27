using System;
using System.Collections.Generic;

class Solution
{
	public int solution(int[] A)
	{
		// Initialize a HashSet to store distinct values
		HashSet<int> seen = new HashSet<int>();

		foreach (var value in A)
		{
			seen.Add(value);
		}

		// Return the count of distinct values
		return seen.Count;
	}
}
