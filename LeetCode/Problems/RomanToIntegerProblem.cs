using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode;

public class RomanToIntegerProblem : IProblem
{
	public void Execute()
	{
		Console.WriteLine(RomanToInt("III"));
		Console.WriteLine(RomanToInt("LVIII"));
		Console.WriteLine(RomanToInt("MCMXCIV"));
	}
	
	public Dictionary<char, int> Romans => new()
	{
		{ 'I', 1 },
		{ 'V', 5 },
		{ 'X', 10 },
		{ 'L', 50 },
		{ 'C', 100 },
		{ 'D', 500 },
		{ 'M', 1000 }
	};
	
	public int RomanToInt(string s)
	{
		var result = 0;
		var intRomans = s.Select(x => Romans[x])
			.ToArray();

		for (var i = 0; i < intRomans.Length - 1; i++)
		{
			if (intRomans[i] < intRomans[i + 1])
			{
				result -= intRomans[i];
			}
			else
			{
				result += intRomans[i];
			}
		}

		result += intRomans.Last();
		return result;
	}
}