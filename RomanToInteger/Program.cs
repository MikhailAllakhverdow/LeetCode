using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine(SecondSolution.RomanToInt("III"));
Console.WriteLine(SecondSolution.RomanToInt("LVIII"));
Console.WriteLine(SecondSolution.RomanToInt("MCMXCIV"));

public static class FirstSolution {
	public static Dictionary<string, int> Romans => new()
	{
		{ "I", 1 },
		{ "IV", 4 },
		{ "V", 5 },
		{ "IX", 9 },
		{ "X", 10 },
		{ "XL", 40 },
		{ "L", 50 },
		{ "XC", 90 },
		{ "C", 100 },
		{ "CD", 400 },
		{ "D", 500 },
		{ "CM", 900 },
		{ "M", 1000 }
	};

	public static int RomanToInt(string s)
	{
		int result = 0;
		for (var i = 0; i < s.Length; i++)
		{
			if (s.Length - i >= 2)
			{
				var doubleDigitString = s.Substring(i, 2);
				if (Romans.TryGetValue(doubleDigitString, out var doubleDigitInt))
				{
					result += doubleDigitInt;
					i++;
					continue;
				}
			}
			result += Romans[s.Substring(i, 1)];
		}

		return result;
	}
}

public static class SecondSolution {
	public static Dictionary<char, int> Romans => new()
	{
		{ 'I', 1 },
		{ 'V', 5 },
		{ 'X', 10 },
		{ 'L', 50 },
		{ 'C', 100 },
		{ 'D', 500 },
		{ 'M', 1000 }
	};
	
	public static int RomanToInt(string s)
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