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
		// goal = to return max possible profit from one transaction 
		// 0 <= P <= Q < N
		// max profit is the largest value from A[Q] - A[P]
		// in order to get max profit we need to track the lowest single share within the array
		// subtract each current index from the lowest single share
		// if the value is higher than the current maxProfit update the maxProfit
		// return it back to solution

		// intialise following variables:
		// currentLowestShare
		// maxProfit

		int maxProfit = 0; // tracks the maxprofit from Q-P (temp set to 0)
		int currentLowestShare = int.MaxValue; // tracks the lowest single share within array (temporarily set to max)

		foreach (int share in A)
		{
			if (share < currentLowestShare)
			{ // loops across each share in the array
				currentLowestShare = share; // if the share is less than the current value (set to max intially) it is updated to the share
			}
			if (maxProfit < share - currentLowestShare)
			{ // if maxProfit is less than the potential profit (from the difference of the share and current lowest share)
				maxProfit = share - currentLowestShare; // we update the maxProfit to this new potential profit value
			}
		}

		return maxProfit; // finally return maxProfit

	}
}