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

		// dominator = value that occurs in more than half of the element in array
		// return index of any element within array where dominator occurs
		//return -1 if no dominator

		// dictionary that tracks key (number) and value (how many times does it appear)
		// each time the dictionary goes over a repeat we increment the value
		// if a number repeats more than half the values within the array 
		// return any index containing that number
		// if this doesn't happen return -1

		Dictionary<int, int> occurences = new Dictionary<int, int>();

		for (int i = 0; i < A.Length; i++)
		{ // counting each number
			int num = A[i];
			if (occurences.ContainsKey(num))
			{
				occurences[num]++; // value assosciated with key is incremented
			}
			else
			{
				occurences[num] = 1; // if it doesn't exist yet we set it to 1
			}
		}

		int dominator = -1;
		int half = A.Length / 2;

		foreach (var pair in occurences)
		{ // finding a dominator if it exists
			if (pair.Value > half)
			{
				dominator = pair.Key; // if the value appears more than half the elements within array this is our dominator
				break;
			}
		}
		if (dominator != -1)
		{ // returning the index wherever a dominator occurs
			for (int i = 0; i < A.Length; i++)
			{
				if (A[i] == dominator) return i;
			}
		}
		return -1;
	}
}