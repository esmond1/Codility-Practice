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
        // leader = value that occurs in more than half the elements of array
        // leader > A.Length / 2
        // equileader has 2 sequences:
        // A[0],A[1],.... A[S]
        // A[S+1],A[S+2],....A[N-1]

        //want to return the no. equi leaders

        // need a variable to track equileader count
        // dictionary with key-value pair (key = number) (value = how many times the number appears)

        // first check if there is a leader if yes -> loop to see if it fills either requirement to be an equileader
        // if it does increment equileader count

        // return equileader count at the end

        Dictionary<int, int> occurences = new Dictionary<int, int>();
        int equileaderCount = 0;
        int half = A.Length / 2;

        foreach (int num in A)
        { // setting up logic to increment value count to find leader
            if (occurences.ContainsKey(num))
            {
                occurences[num]++;
            }
            else
            {
                occurences[num] = 1;
            }
        }

        int leader = -1;
        int leaderCount = 0;
        int leftLeaderCount = 0;

        foreach (var pair in occurences)
        {
            if (pair.Value > half)
            { // if the number of occurences is greater than half the elements within array
                leader = pair.Key; // the key is the leader (dominator)
                leaderCount = pair.Value; // the value is the total leadercount (how many times it appeared)
                break;
            }
        }

        for (int i = 0; i < A.Length - 1; i++)
        { //equileader checks
            // Looping through indices up to A.Length - 1 to ensure we can divide the array into two parts (left and right).
            // if current index value is = leader value (sequence 1)
            // left side leader count is incremented
            if (A[i] == leader)
            {
                leftLeaderCount++;
            }

            // total leadercount - left side(s1) = right side (s2)

            int rightLeaderCount = leaderCount - leftLeaderCount; // Right leader count is the remaining occurrences of the leader after accounting for the left part.


            //check to see if left leader count (sequence1) is greater than half eleemnts in array 
            // check to see if right leader count (sequence2) is greater than half element in array
            if (leftLeaderCount > (i + 1) / 2 && rightLeaderCount > (A.Length - i - 1) / 2)
            {
                //if yes equileaderCount is incremented
                equileaderCount++;
            }

        }
        return equileaderCount;
    }
}