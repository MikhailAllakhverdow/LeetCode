using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
	public class LongestSubstringWithoutRepeatingCharactersProblem : IProblem
	{
		public void Execute()
		{
			Console.WriteLine(LengthOfLongestSubstring("abcabdcbb"));
			Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
			Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
			Console.WriteLine(LengthOfLongestSubstring("dvdf"));
			Console.WriteLine(LengthOfLongestSubstring("abba"));
		}

		public int LengthOfLongestSubstring(string s)
		{
			var dictionary = new Dictionary<char, int>();
			var start = 0;
			var end = 0;
			var max = 0;

			if (string.IsNullOrEmpty(s))
			{
				return 0;
			}

			for (int i = 0; i < s.Length; i++)
			{
				if (dictionary.ContainsKey(s[i]))
				{
					start = Math.Max(start, dictionary[s[i]] + 1);
				}
				
				dictionary[s[i]] = i;
				end++;
				max = Math.Max(end - start, max);
			}
			
			return max;
		}
	}
}