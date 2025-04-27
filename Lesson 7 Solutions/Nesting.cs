using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
	public int solution(string S)
	{
		// Implement your solution here
		// nested = corresponding closing bracket to opening bracket
		// stack to push and track opening brackets
		// if logic where if the opening brackets doesn't have a corresponding closing bracket return 0 and break
		// if stack is empty theres no corresponding  oepning bracket
		// finally using tertenary operator with the condition properlyNestedCount = 0 ? 1: 0

		Stack<char> nested = new Stack<char>();
		int properlyNestedCount = 0;

		for (int i = 0; i < S.Length; i++)
		{
			if (S[i] == '(')
			{
				nested.Push(S[i]);
			}
			else if (S[i] == ')')
			{
				if (nested.Count == 0)
				{
					return 0;
				}
				nested.Pop();
			}
		}

		return nested.Count == 0 ? 1 : 0;

	}
}