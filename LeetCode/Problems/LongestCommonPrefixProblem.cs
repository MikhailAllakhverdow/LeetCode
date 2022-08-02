using System;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
	public class LongestCommonPrefixProblem : IProblem
	{
		public void Execute()
		{
			Console.WriteLine(LongestCommonPrefix("flower","flow","flight"));
			Console.WriteLine(LongestCommonPrefix("dog","racecar","car"));
		}
		
		public string LongestCommonPrefix(params string[] strs) {
			var firstString = strs[0];
			var sb = new StringBuilder();

			for (int i = 0; i < firstString.Length; i++){
				for (int j = 0; j < strs.Length; j++)
				{
					if (strs[j].Length <= i || strs[j][i] != firstString[i])
						return sb.ToString();
				}

				sb.Append(firstString[i]);
			}

			return sb.ToString();
		}
	}
}