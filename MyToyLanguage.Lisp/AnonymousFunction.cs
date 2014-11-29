using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	internal class AnonymousFunction : LispFunction
	{
		private readonly string[] _arguments;
		private readonly LispExpression _body;

		public AnonymousFunction(string[] arguments, LispExpression body)
		{
			_arguments = arguments;
			_body = body;
		}

		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			if (_arguments.Length != e.Length)
			{
				throw new InvalidOperationException();
			}
			var childContext = new ChildContext(context);
			for (int i = 0; i < _arguments.Length; i++)
			{
				childContext[_arguments[i]] = e[i].Reduce(context);
			}
			return _body.Reduce(childContext);
		}
	}
}
