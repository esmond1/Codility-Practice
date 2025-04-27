using System.Collections.Generic;

class Solution
{
    public int solution(int[] A)
    {
        // Implement your solution here
        // valid peak =  A[P - 1] < A[P] && A[P] > A[P + 1]
        // valid block = [ five elements] [five elements]
        // essentially a block is when the array is divided into sections containing the same number of elements
        // each block must have at least one peak
        // extreme elements can be peaks only if they have both neighbours (can be in adjacent blocks)

        // to begin we can create a list of peaks which will add each peak within array
        // we add the index of each peak to list
        // for every position a peak is in we want to split the array
        // eg. 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2
        // A[3] A[5] A[10] are all peaks
        // to split array right after a peak would give
        // [1,2,3,4] A[3] peak - [3, 4, 1, 2] A[5] peak - [3,4,6,2] A[10] peak
        // 3 valid blocks containing 4 elements each
        // some type of if logic where you work out the max number of potential blocks (array length / no.peaks)
        // once we have max num of potential blocks we then try to fill the blocks in order of indices
        // if they don't contain the same no.elements OR at least one peak we reduce the no.blocks and try again
        // do this until we have a valid block containing: >=1 peak + same number of elements in every block

        List<int> peaks = new List<int>();
        int N = A.Length;

        // Adding our peaks to list
        for (int i = 1; i < N - 1; i++)
        {
            if (A[i - 1] < A[i] && A[i] > A[i + 1])
            {
                peaks.Add(i);
            }
        }
        if (peaks.Count == 0) return 0; // If no peaks, return 0

        // Trying all possible number of blocks
        for (int size = N; size >= 1; size--)
        { // Try from largest number of blocks down to 1
            if (N % size != 0) continue; // Only consider sizes that divide the array evenly
            int blockSize = N / size; // Block size (number of elements per block)
            int validBlocks = 0; // Number of blocks with at least one peak
            int peakIndex = 0; // Index in peaks list

            // Check each block for at least one peak
            for (int block = 0; block < size; block++)
            {
                bool foundPeakInBlock = false;
                while (peakIndex < peaks.Count && peaks[peakIndex] < (block + 1) * blockSize)
                {
                    if (peaks[peakIndex] >= block * blockSize)
                    {
                        foundPeakInBlock = true;
                        peakIndex++; // Move to the next peak
                    }
                }
                if (foundPeakInBlock)
                {
                    validBlocks++; // This block has a peak
                }
            }
            if (validBlocks == size) return size; // Return the first valid block size
        }

        return 0; // No valid solution found
    }
}