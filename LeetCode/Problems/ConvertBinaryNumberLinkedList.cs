using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
	public class ConvertBinaryNumberLinkedList : IProblem
	{
		public void Execute()
		{
			var node3 = new ListNode(1);
			var node2 = new ListNode(0, node3);
			var node1 = new ListNode(1, node2);
			Console.WriteLine(GetDecimalValue(node1));
		}
		
		public int GetDecimalValue(ListNode head) {
			var current = head;
			var binary = new Stack<int>();
			var result = 0;
			var multiplier = 1;
			
			while (current != null)
			{
				binary.Push(current.val);
				current = current.next;
			}

			while (binary.TryPop(out var value))
			{
				result += value * multiplier;
				multiplier *= 2;
			}
        
			return result;
		}
	}

	public class ListNode
	{
		public int val;
		public ListNode next;

		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
	}
}