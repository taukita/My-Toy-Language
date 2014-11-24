using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToyLanguage.Lisp.Functions;

namespace MyToyLanguage.Lisp
{
	public class LispContext : Dictionary<string, LispExpression>
	{
		public LispContext()
		{
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
			this[function.Id] = function;
		}

		private void RegisterFunction(string id, Func<IEnumerable<LispExpression>, LispExpression> func)
		{
			this[id] = new LispFunction(func);
		}
	}
}
