using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // يمكنك استدعاء أي دالة هنا للتجربة
        Console.WriteLine("--- Testing Loop Task 1 ---");
        LoopTasks.ZigZagNumbers(5);
        
        Console.WriteLine("\n--- Testing Array Task 5 ---");
        ArrayTasks.LongestStableSegment(new int[] { 1, 2, 2, 3, 1, 2 });

        Console.WriteLine("\n--- Testing String Task 1 ---");
        StringTasks.RemoveAdjacentOpposites("aAbBcC");
    }
}

// 🔵 قسم الـ Loops
public static class LoopTasks
{
    // 1. ZigZag Numbers
    public static void ZigZagNumbers(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0)
                for (int j = 1; j <= i; j++) Console.Write(j);
            else
                for (int j = i; j >= 1; j--) Console.Write(j);
            Console.WriteLine();
        }
    }

    // 2. Mirror Number Pattern
    public static void MirrorPattern(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++) Console.Write(j);
            for (int s = 0; s < (n - i) * 2; s++) Console.Write(" ");
            for (int j = i; j >= 1; j--) Console.Write(j);
            Console.WriteLine();
        }
    }

    // 3. Centered Number Pyramid
    public static void CenteredPyramid(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            Console.Write(new string(' ', n - i));
            for (int j = 1; j <= i; j++) Console.Write(j);
            for (int j = i - 1; j >= 1; j--) Console.Write(j);
            Console.WriteLine();
        }
    }

    // 4. Skip Numbers Pattern
    public static void SkipNumbers(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++) Console.Write(1 + (j * 2));
            Console.WriteLine();
        }
    }

    // 5. Row Sum Pattern
    public static void RowSumPattern(int n)
    {
        int val = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++) Console.Write(val + " ");
            val *= 2;
            Console.WriteLine();
        }
    }

    // 6. Alternating Direction Triangle (Same as ZigZag logic)
    public static void AlternatingTriangle(int n) => ZigZagNumbers(n);

    // 7. Hollow Pyramid Numbers
    public static void HollowPyramid(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int s = 1; s <= n - i; s++) Console.Write(" ");
            for (int j = 1; j <= (2 * i - 1); j++)
            {
                if (i == n || j == 1 || j == (2 * i - 1)) Console.Write("1");
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    // 8. Diagonal Cross Pattern
    public static void DiagonalCross(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j || j == n - i + 1) Console.Write(i);
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    // 9. Incremental Blocks
    public static void IncrementalBlocks(int n)
    {
        int count = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++) Console.Write(count++ + " ");
            Console.WriteLine();
        }
    }

    // 10. Pattern with Gaps
    public static void PatternWithGaps(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i == n) Console.WriteLine(new string('1', n + 1));
            else
            {
                Console.Write("1");
                Console.Write(new string(' ', i));
                Console.WriteLine("1");
            }
        }
    }
}

// 🟢 قسم الـ Array
public static class ArrayTasks
{
    // 1. First Non-Repeating Subarray
    public static void FirstUniqueSubarray(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] != arr[i + 1])
            {
                Console.WriteLine($"[{arr[i]},{arr[i+1]}]");
                return;
            }
        }
    }

    // 5. Longest Stable Segment (|max-min| <= 1)
    public static void LongestStableSegment(int[] arr)
    {
        int maxLen = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int min = arr[i], max = arr[i];
            for (int j = i; j < arr.Length; j++)
            {
                min = Math.Min(min, arr[j]);
                max = Math.Max(max, arr[j]);
                if (max - min <= 1) maxLen = Math.Max(maxLen, j - i + 1);
                else break;
            }
        }
        Console.WriteLine(maxLen);
    }

    // 7. Progressive Difference
    public static void ProgressiveDifference(int[] arr)
    {
        int[] res = new int[arr.Length];
        res[0] = arr[0];
        for (int i = 1; i < arr.Length; i++) res[i] = arr[i] - arr[i - 1];
        Console.WriteLine(string.Join(",", res));
    }

    // 9. Prefix Balance Point
    public static void PrefixBalance(int[] arr)
    {
        int totalSum = arr.Sum();
        int leftSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (leftSum == totalSum - leftSum - arr[i]) { Console.WriteLine(i); return; }
            leftSum += arr[i];
        }
    }
}

// 🟣 قسم الـ String
public static class StringTasks
{
    // 1. Remove Adjacent Opposites (aA, Aa)
    public static void RemoveAdjacentOpposites(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (stack.Count > 0 && Math.Abs(stack.Peek() - c) == 32) stack.Pop();
            else stack.Push(c);
        }
        Console.WriteLine(new string(stack.Reverse().ToArray()));
    }

    // 2. Compress Keep Order
    public static void CompressOrder(string s)
    {
        var dict = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (dict.ContainsKey(c)) dict[c]++;
            else dict[c] = 1;
        }
        foreach (var kp in dict) Console.Write($"{kp.Key}{kp.Value}");
        Console.WriteLine();
    }

    // 5. Reverse Only Letters
    public static void ReverseLetters(string s)
    {
        char[] arr = s.ToCharArray();
        int i = 0, j = s.Length - 1;
        while (i < j)
        {
            if (!char.IsLetter(arr[i])) i++;
            else if (!char.IsLetter(arr[j])) j--;
            else { 
                char temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; 
                i++; j--; 
            }
        }
        Console.WriteLine(new string(arr));
    }

    // 8. Remove One to Make Palindrome
    public static void CanBePalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            string temp = s.Remove(i, 1);
            char[] rev = temp.ToCharArray();
            Array.Reverse(rev);
            if (temp == new string(rev)) { Console.WriteLine("Yes"); return; }
        }
        Console.WriteLine("No");
    }
}