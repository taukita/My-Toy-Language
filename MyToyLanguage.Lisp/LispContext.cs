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
		private readonly Dictionary<string, LispExpression> _boundSymbols;

		public LispContext()
		{
			_functions = new Dictionary<string, LispFunction>();
			_boundSymbols = new Dictionary<string, LispExpression>();

			RegisterFunction(new AddFunction());
			RegisterFunction(new MultiplyFunction());
			RegisterFunction(new SubtractFunction());
			RegisterFunction(new DivideFunction());

			RegisterFunction("list", e => new LispList(e));
			RegisterFunction("close", e => { throw new CloseReplException(); });

			RegisterFunction(new IfFunction());
			RegisterFunction(new SetFunction());
		}

		private void RegisterFunction(LispFunction function)
		{
			_functions[function.Id] = function;
			_boundSymbols[function.Id] = function;
		}

		private void RegisterFunction(string id, Func<IEnumerable<LispExpression>, LispExpression> func)
		{
			_functions[id] = new LispFunction(func);
			_boundSymbols[id] = _functions[id];
		}

		internal LispFunction GetFunction(string id)
		{
			return _functions[id];
		}

		internal LispExpression this[string id]
		{
			get
			{
				return _boundSymbols[id];
			}
			set
			{
				_boundSymbols[id] = value;
			}
		}
	}
}
