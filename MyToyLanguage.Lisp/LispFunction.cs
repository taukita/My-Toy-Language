using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToyLanguage.Lisp
{
	internal class LispFunction : LispExpression
	{
		private readonly Func<IEnumerable<LispExpression>, LispExpression> _func;

		public LispFunction(Func<IEnumerable<LispExpression>, LispExpression> func)
		{
			_func = func;
		}

		protected LispFunction()
		{
		}

		public virtual string Id
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public virtual LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			return _func(expressions);
		}

		public override LispExpression Reduce(LispContext context)
		{
			throw new NotSupportedException();
		}

		protected void CanBeCalledWithOnlyNArguments(string id, IEnumerable<LispExpression> arguments, int n)
		{
			if (arguments.Count() < n)
			{
				throw new FunctionArityException(string.Format("Function '{0}' can be called with only {1} arguments.", id, n));
			}
		}

		protected void CannotBeCalledWithFewerThanNArguments(string id, IEnumerable<LispExpression> arguments, int n)
		{
			if (arguments.Count() < n)
			{
				throw new FunctionArityException(string.Format("Function '{0}' cannot be called with fewer than {1} arguments.", id,
				                                               n));
			}
		}

		protected void CannotBeCalledWithZeroArguments(string id, IEnumerable<LispExpression> arguments)
		{
			if (!arguments.Any())
			{
				throw new FunctionArityException(string.Format("Function '{0}' cannot be called with zero arguments.", id));
			}
		}
	}
}