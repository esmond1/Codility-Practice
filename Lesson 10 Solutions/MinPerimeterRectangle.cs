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
		// N = area of rectangle
		// rectangle area = A*B
		// rectangle perimeter = 2*(A+B)
		// goal = minimal perimeter of any rectange where area = N
		// eg. N = 30
		// (1,30) (2, 15) (3,10) (5,6)
		// Perimeter = 62, 34, 26, 22
		// return 22
		// minPerimeter = int.MaxValue; // will store the lowest perimeter of a rectangle
		// loop where we iterate of each number(A) from 1 up to the the sqrt of the area 
		// if A leaves no remainder  we will know the value of the other side (B)
		// eg. when A = 1 and N = 30 -> 30/1 will give B
		// then we do 2*(A+B) to get currentperimeter
		// do a minPerimeter = Math.Min check between currentperimeter and minPerimeter and update accordingly
		// some logic to ignore sqrt values that aren't whole integers

		int lowestPerimeter = int.MaxValue; // set to max value temporarily
		int currentPerimeter = 0;
		int sqrtN = (int)Math.Sqrt(N);

		for (int A = 1; A <= sqrtN; A++)
		{
			if (N % A == 0)
			{
				int B = N / A;
				currentPerimeter = 2 * (A + B);
				lowestPerimeter = Math.Min(lowestPerimeter, currentPerimeter);
			}
		}
		return lowestPerimeter;

	}
}