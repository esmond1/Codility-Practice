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
        // properly nested if:
        // each opening bracket is corresponding to its ending bracket
        // or empty
        // return 1 but if not return 0
        // stack method to push each opening bracket to the top of stack 

        Stack<char> nested = new Stack<char>();

        foreach (char ch in S)
        { //loop to now check each character in S and push to stack
          // If it's an opening bracket, push it onto the stack
            if (ch == '(' || ch == '{' || ch == '[')
            {
                nested.Push(ch);
            }
            else
            {// otherwise return 0 -- if theres no opening bracket it cant be nested to begin with

                if (nested.Count == 0)
                { // if the nested count is 0 we found no opening brackets and return 0
                    return 0;
                }

                char top = nested.Pop();  // Pop the last opened bracket and check if it matches the closing one

                if (ch == ')' && top != '(') return 0; // if closing bracket doesn't match corresponding opening bracket we return 0
                if (ch == ']' && top != '[') return 0;
                if (ch == '}' && top != '{') return 0;
            }
        }

        if (nested.Count == 0)
        { // if nested count doesn't equal 0 we have at least one properly nested within S
            return 1;
        }
        else
        {
            return 0;
        }
    }
}