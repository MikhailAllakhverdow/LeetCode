using System;
using System.Collections.Generic;

Console.WriteLine(Solution.Reverse(1434236469));

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

public class Solution {
	public static int Reverse(int x) {
		var result = 0;
        
		while (x != 0) {
			if ((long)(result * 10) > int.MaxValue || (long)(result * 10) < int.MinValue)
				return 0;
			var t = new HashSet<char>();
			string.Is
			t.Clear();
			string s;
			result *= 10;
			result += (x % 10);
			x /= 10;
		}
        
		return result;
	}
}