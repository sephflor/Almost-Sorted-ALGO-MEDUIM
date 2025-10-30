using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    /*
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    public static void almostSorted(List<int> arr)
    {
        int n = arr.Count;
        List<int> sorted = new List<int>(arr);
        sorted.Sort();

        if (arr.SequenceEqual(sorted))
        {
            Console.WriteLine("yes");
            return;
        }

        // Find the first and last index where arr differs from sorted
        int l = 0, r = n - 1;
        while (l < n && arr[l] == sorted[l]) l++;
        while (r >= 0 && arr[r] == sorted[r]) r--;

        // Try swapping
        Swap(arr, l, r);
        if (arr.SequenceEqual(sorted))
        {
            Console.WriteLine("yes");
            Console.WriteLine($"swap {l + 1} {r + 1}");
            return;
        }
        // Undo swap
        Swap(arr, l, r);

        // Try reversing
        arr.Reverse(l, r - l + 1);
        if (arr.SequenceEqual(sorted))
        {
            Console.WriteLine("yes");
            Console.WriteLine($"reverse {l + 1} {r + 1}");
        }
        else
        {
            Console.WriteLine("no");
        }
    }

    private static void Swap(List<int> arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> arr = new List<int>(Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse));

        almostSorted(arr);
    }
}
