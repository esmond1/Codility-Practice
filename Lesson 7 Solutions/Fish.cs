using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(int[] A, int[] B)
	{
		Stack<int> downstreamFish = new Stack<int>();
		int upstreamFishCount = 0;

		// stack that tracks and records the number of downstream fish (B[i] = 1)
		// for each downstreamfish we push to the stack
		// for each upstream fish we check:
		// are there any downstream in stack atm -> if no U fish continues to survive (increment u fish count)
		// is the U fish size > D fish size -> if yes use pop method to remove most recently added fish -> if no end while loop
		// finally return ( no. d fish in stack + u fish that survive)

		// for loop over each fish and need to use both arrays 
		// if B[i] == d fish push A[i] to stack
		// if B [i] == u fish we enter while loop 
		// while -> the size of u fish is > size of d fish we pop the stack 
		// if d fish size > u fish size leave the stack untoucched 
		// if stack is empty the upstream fish survived -> u fish count++
		for (int i = 0; i < B.Length; i++)
		{
			if (B[i] == 1)
			{
				// Downstream fish goes on the stack
				downstreamFish.Push(A[i]);
			}
			else
			{
				// Upstream fish encounters downstream fish (if any)
				while (downstreamFish.Count > 0)
				{
					int recentDFish = downstreamFish.Peek();

					if (A[i] > recentDFish)
					{
						downstreamFish.Pop(); // Upstream eats downstream
					}
					else
					{
						break; // Upstream fish is eaten
					}
				}

				// If upstream fish survived all downstream fish
				if (downstreamFish.Count == 0)
				{
					upstreamFishCount++;
				}
			}
		}

		return upstreamFishCount + downstreamFish.Count;
	}
}