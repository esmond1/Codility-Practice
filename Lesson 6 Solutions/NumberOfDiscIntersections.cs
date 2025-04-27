using System;

class Solution
{
	public int solution(int[] A)
	{
		int N = A.Length;

		// Two arrays to store the start and end points of each disc
		long[] start = new long[N];
		long[] end = new long[N];

		// Fill the start and end arrays
		for (int i = 0; i < N; i++)
		{
			start[i] = (long)i - A[i];  // Start point: i - radius
			end[i] = (long)i + A[i];    // End point: i + radius
		}

		// Sort the start and end arrays
		Array.Sort(start);
		Array.Sort(end);

		int ongoingDiscs = 0;  // Track the number of ongoing discs
		int intersections = 0; // Track the number of intersections
		int j = 0; // Pointer for the start points array

		// Iterate over each end point
		for (int i = 0; i < N; i++)
		{
			// While the current start point is less than or equal to the current end point
			while (j < N && start[j] <= end[i])
			{
				ongoingDiscs++;  // A disc is ongoing, so increment the count
				j++;  // Move to the next start point
			}

			// Add ongoing discs to the intersection count
			intersections += ongoingDiscs;

			// Subtract 1 to exclude the current disc (it shouldn't intersect with itself)
			intersections -= 1;

			// If the intersections exceed 10 million, return -1
			if (intersections > 10000000)
			{
				return -1;
			}

			// Decrement ongoing discs to account for the current disc that has ended
			ongoingDiscs--;
		}

		// Return the total number of intersections
		return intersections;
	}
}
