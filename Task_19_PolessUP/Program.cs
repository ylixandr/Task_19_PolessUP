using System;

public class Solution
{
    public int[] RearrangeBarcodes(int[] barcodes)
    {
        int n = barcodes.Length;
        int[] counts = new int[10001];
        int maxCount = 0;
        int maxValue = 0;

        foreach (int barcode in barcodes)
        {
            counts[barcode]++;
            if (counts[barcode] > maxCount)
            {
                maxCount = counts[barcode];
                maxValue = barcode;
            }
        }

        int[] result = new int[n];
        int index = 0;

        while (maxCount > 0)
        {
            result[index] = maxValue;
            index += 2;
            maxCount--;
        }

        counts[maxValue] = 0;

        for (int i = 0; i < counts.Length; i++)
        {
            while (counts[i] > 0)
            {
                if (index >= n)
                    index = 1;

                result[index] = i;
                index += 2;
                counts[i]--;
            }
        }

        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] barcodes = { 1, 1, 1, 2, 2, 2 };
        Solution solution = new Solution();
        int[] result = solution.RearrangeBarcodes(barcodes);
        Console.WriteLine(string.Join(", ", result));
    }
}
