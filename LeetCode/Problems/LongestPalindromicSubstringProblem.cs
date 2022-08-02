using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
	public class LongestPalindromicSubstringProblem : IProblem
	{
		public void Execute()
		{
			Console.WriteLine(LongestPalindrome("babad"));
			Console.WriteLine(LongestPalindrome("abbd"));
			Console.WriteLine(LongestPalindrome("ssaabcbaax"));
		}
		
		public string LongestPalindrome(string s)
		{
			if (s == "" || s.Length == 1)
			{
				return s;
			}
			
			var start = 0;
			var length = 0;
			var unevenPalindromeLength = 0;
			var evenPalindromeLength = 0;
			for (int i = 0; i < s.Length; i++)
			{
				 evenPalindromeLength = GetPalindromeLength(s, i, i);
				 unevenPalindromeLength = GetPalindromeLength(s, i, i + 1);

				 if (Math.Max(evenPalindromeLength, unevenPalindromeLength) > length)
				 {
					 length = Math.Max(evenPalindromeLength, unevenPalindromeLength);
					 start = i - (length -1) / 2;
				 }
			}

			return s.Substring(start, length);
		}

		private int GetPalindromeLength(string s, int left, int right)
		{
			while (left >= 0 && right < s.Length && s[left] == s[right])
			{
				left--;
				right++;
			}

			return right - left - 1;
		}
	}
}