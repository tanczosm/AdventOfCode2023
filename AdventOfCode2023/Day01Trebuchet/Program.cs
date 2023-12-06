using System.Linq;
using System.Runtime.ExceptionServices;

void One()
{
	var lines = File.ReadAllLines("input.txt");

	var nums = lines.Select(x =>
			x.Where(Char.IsDigit).First() + "" +
			x.Where(Char.IsDigit).Last())
		.Select(x => Convert.ToInt32(x))
		.Sum();

	//Console.WriteLine(nums);

	var solution = lines
		.Select(x => $"{x.First(char.IsDigit)}{x.Last(char.IsDigit)}")
		.Select(int.Parse)
		.Sum();

	Console.WriteLine($"Problem one: {solution}");

}

void Two()
{
	int Parse(string line)
	{
		var digits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }.ToList();
		var output = new List<int>();

		for (int i = 0; i < line.Length; i++)
		{
			if (int.TryParse(line.AsSpan(i, 1), out int digit))
				output.Add(digit);
			else
			{
				for (int k = 0; k < digits.Count; k++)
				{
					var part = new string(line.Skip(i).Take(digits[k].Length).ToArray());

					if (part == digits[k])
					{
						output.Add(k);
						break;
					}
				}
			}
		}

		return output.First() * 10 + output.Last();
	}

	var lines = File.ReadAllLines("input.txt");

	var solution = lines.Select(Parse).Sum();

	Console.WriteLine($"Problem two: {solution}");
}

One();
Two();
