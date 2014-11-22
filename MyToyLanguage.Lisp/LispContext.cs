using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToyLanguage.Lisp.Functions;

namespace MyToyLanguage.Lisp
{
	public class LispContext
	{
		private readonly Dictionary<string, LispFunction> _functions;

		public LispContext()
		{
			_functions = new Dictionary<string, LispFunction>();

			_functions["+"] = new AddFunction();
			_functions["*"] = new MultiplyFunction();
			_functions["-"] = new SubtractFunction();
			_functions["/"] = new DivideFunction();

			_functions["list"] = new LispFunction(e => new LispList(e));
		}

		internal LispFunction GetFunction(string id)
		{
			return _functions[id];
		}
	}
}
