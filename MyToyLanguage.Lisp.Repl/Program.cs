using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Repl
{
	class Program
	{
		static void Main(string[] args)
		{
			var context = new LispContext();
			while (true)
			{
				Console.Write("<<< ");
				var input = Console.ReadLine();
				try
				{
					var expression = ToyLispParser.ParseExpression(input).Reduce(context);
					Console.WriteLine(">>> {0}", expression);
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
