using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	internal class LispFunction
	{
		private readonly Func<IEnumerable<LispExpression>, LispExpression> _func;

		public LispFunction(Func<IEnumerable<LispExpression>, LispExpression> func)
		{
			_func = func;
		}

		protected LispFunction()
		{
		}

		public virtual LispExpression Apply(IEnumerable<LispExpression> expressions)
		{
			return _func(expressions);
		}

		protected void CannotBeCalledWithZeroArguments(string id, IEnumerable<LispExpression> arguments)
		{
			if (!arguments.Any())
			{
				throw new FunctionArityException(string.Format("Function '{0}' cannot be called with zero arguments.", id));
			}
		}

		protected void CannotBeCalledWithFewerThanNArguments(string id, IEnumerable<LispExpression> arguments, int n)
		{
			if (arguments.Count() < n)
			{
				throw new FunctionArityException(string.Format("Function '{0}' cannot be called with fewer than {1} arguments.", id, n));
			}
		}
	}
}
