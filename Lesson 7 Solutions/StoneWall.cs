using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(int[] H)
	{
		// Implement your solution here
		// left end of wall = H[0]
		// right end of wall = H[N-1]
		// H[I] = height of wall from I - I+1 metres to the right of its left end
		// return the min no.blocks needed to build wall
		// wall is N metres long but different heights at different places

		// stack where:
		// if current height is higher than previous need to add a new block
		// if equal to prev then ignore (counts as one block eg. H = 8 and following H = 8 then this is one block)
		// if less than then end current block and begin new one at that height

		// the stack will track open block heights
		// counter needed to record how many blocks were needed 

		Stack<int> blockHeights = new Stack<int>();
		int BlockCounter = 0;

		for (int i = 0; i < H.Length; i++)
		{
			while (blockHeights.Count > 0 && H[i] < blockHeights.Peek())
			{
				blockHeights.Pop(); // Pop = closing off finished block heights when wall gets shorter.
			}
			if (blockHeights.Count == 0 || H[i] != blockHeights.Peek())
			{
				blockHeights.Push(H[i]); // Push + count++ = starting a new block because no existing block matches the current height.
				BlockCounter++;
			}

		}

		return BlockCounter;

	}
}