using System;

namespace LeetCode.Problems
{
	public class TrappingRainWaterProblem : IProblem
	{
		public void Execute()
		{
			Console.WriteLine(Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
		}
		
		public int Trap(int[] height) {
			var n = height.Length;
			var lmax = 0;
			var rmax = 0;
			var l = 0;
			var r = n - 1;
			var result = 0;

			while (l <= r)
			{
				if (rmax > lmax)
				{
					result += Math.Max(0, lmax - height[l]);
					lmax = Math.Max(lmax, height[l]);
					l++;
				}
				else
				{
					result += Math.Max(0, rmax - height[r]);
					rmax = Math.Max(rmax, height[r]);
					r--;
				}
			}
			
			return result;
		}
	}
}