/*
2. Add Two Numbers

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [7,0,8]
    Explanation: 342 + 465 = 807.

Example 2:
    Input: l1 = [0], l2 = [0]
    Output: [0]

Example 3:
    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    Output: [8,9,9,9,0,0,0,1]

Constraints:
    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros.

https://leetcode.com/problems/add-two-numbers/description/
*/
namespace LeetCodePractice01;

public class AddTwoNumbers
{
    public static ListNode? AddTwoNumberss(ListNode? l1, ListNode? l2)
    {
        if (l1 is null) return l2;
        if (l2 is null) return l1;

        ListNode? result = new(0);
        ListNode? temp = result;
        int sum = 0;
        int carry = 0;
        while (l1 is not null && l2 is not null)
        {
            sum = l1.val + l2.val + carry;
            temp.next = new(sum % 10);
            temp = temp.next;
            carry = sum / 10;
            l1 = l1.next;
            l2 = l2.next;
        }

        if (l1 is null)
        {
            while (l2 is not null)
            {
                sum = l2.val + carry;
                temp.next = new(sum % 10);
                temp = temp.next;
                l2 = l2.next;
            }
        }
        else if (l2 is null)
        {
            while (l1 is not null)
            {
                sum = l1.val + carry;
                temp.next = new(sum % 10);
                temp = temp.next;
                l1 = l1.next;
            }
        }

        if (carry != 0)
        {
            temp.next = new(carry);
        }

        return result.next;
    }

    public static void TestAddTwoNumberss()
    {
        ListNode[] l1 = [
            new([2,4,3]),
            new([0]),
            new([9,9,9,9,9,9,9])
        ];
        ListNode[] l2 = [
            new([5,6,4]),
            new([0]),
            new([9,9,9,9])
        ];

        ListNode[] expecteds = [
            new([7,0,8]),
            new([0]),
            new([8,9,9,9,0,0,0,1])
        ];

        for (int i = 0; i < l1.Length; i++)
        {
            bool testResult = true;
            ListNode? output = AddTwoNumberss(l1[i], l2[i]);
            ListNode? expected = expecteds[i];
            while (expected is not null && output is not null)
            {
                if (expected.val != output?.val)
                {
                    testResult = false;
                    break;
                }
                expected = expected.next;
                output = output.next;
            }
            Console.WriteLine($"{i}: {testResult}");
        }
    }
}

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] values)
    {
        this.val = values[0];
        ListNode current = this;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
    }
}
