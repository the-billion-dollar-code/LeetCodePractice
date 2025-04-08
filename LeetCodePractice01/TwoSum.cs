/*
https://leetcode.com/problems/two-sum/

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1]

Example 2:
    Input: nums = [3,2,4], target = 6
    Output: [1,2]

Example 3:
    Input: nums = [3,3], target = 6
    Output: [0,1]

Constraints:
    2 <= nums.length <= 104
    -109 <= nums[i] <= 109
    -109 <= target <= 109

Only one valid answer exists.

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

*/

namespace LeetCodePractice01;

class TwoSum
{
    public static int[] TwoSumm(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            int num1 = target - nums[i];
            if (map.ContainsKey(num1))
            {
                return [map[num1], i];
            }
            map[nums[i]] = i;
        }
        return new int[2];
    }

    public static void TestTwoSumm()
    {
        int[][] inputs = [
            [2, 7, 11, 15],
            [3, 2, 4],
            [3,3]
        ];
        int[] targetSums = [
            9,
            6,
            6
        ];
        int[][] expecteds = [
            [0, 1],
            [1, 2],
            [0, 1]
        ];

        for (var i = 0; i < inputs.Length; i++)
        {
            int[] input = inputs[i];
            int targetSum = targetSums[i];
            int[] expected = expecteds[i];
            int[] output = TwoSumm(input, targetSum);
            bool result = (output[0] == expected[0] && output[1] == expected[1]) || (output[0] == expected[1] && output[1] == expected[0]);

            Console.WriteLine($"i: {i}\t input: [{String.Join(", ", input),-30}]\t target sum: {targetSum}\t output: [{String.Join(", ", output)}]\t result: {result}");
        }
    }
}
