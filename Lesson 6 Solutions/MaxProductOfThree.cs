using System;

class Solution
{
	public int solution(int[] A)
	{
		// Sort the array in ascending order
		Array.Sort(A);

		// Calculate the product of the three largest elements
		int num1 = A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3];

		// Calculate the product of the two smallest (most negative) and the largest element
		int num2 = A[0] * A[1] * A[A.Length - 1];

		// Return the maximum of the two products
		return Math.Max(num1, num2);
	}
}
