// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

namespace LeetCode
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var availableProblems = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => typeof(IProblem).IsAssignableFrom(p) && p.IsClass);

			Console.WriteLine("Problems available for execution:");
			foreach (var availableProblem in availableProblems)
			{
				Console.WriteLine(availableProblem.Name);
			}

			do
			{
				Console.WriteLine("\nEnter problem to execute:");
				var problemToExecute = Console.ReadLine().ToLowerInvariant();
				var problem = availableProblems.FirstOrDefault(x => x.Name.ToLowerInvariant().StartsWith(problemToExecute));

				if (problem == null)
				{
					Console.WriteLine($"Problem named {problemToExecute} does not exist.");
				}
				else
				{
					var problemInstance = (IProblem)Activator.CreateInstance(problem);
					problemInstance.Execute();
				}
			} while (true);
		}
	}
}