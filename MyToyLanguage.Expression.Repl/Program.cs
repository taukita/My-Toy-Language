using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Expression.Repl
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("<<< ");
				var input = Console.ReadLine();
				try
				{
					var expression = ToyExpressionParser.ParseExpression(input);
					Console.Write(">>> ");
					Console.WriteLine(expression.Reduce(null));
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				Console.WriteLine();
			}
		}
	}
}
