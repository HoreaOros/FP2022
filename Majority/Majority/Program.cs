using System;

public class Program
{
    public static void Main()
    {
        Solution s = new Solution();
        int[] nums = { 3, 2, 3 };
        Console.WriteLine(s.MajorityElement(nums));
    }
}
public class Solution
{
    
    public int MajorityElement(int[] nums)
    {
        int contor;
        int majority = 0;
        bool found = false;
        for (int i = 0; i < nums.Length; i++)
        {
            contor = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    contor++;
                }
            }
            if (contor > nums.Length / 2)
            {
                majority = nums[i];
                found = true;
            }
        }
        if (found)
        {
            return majority;
        }
        else
            throw new Exception();
    }
}