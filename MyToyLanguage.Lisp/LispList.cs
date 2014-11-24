using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToyLanguage.Lisp
{
	public class LispList : LispExpression
	{
		protected readonly LispExpression[] Expressions;

		public LispList(IEnumerable<LispExpression> expressions)
		{
			Expressions = expressions as LispExpression[] ?? expressions.ToArray();
		}

		public override LispExpression Reduce(LispContext context)
		{
			if (Expressions.Length > 0)
			{
				if (!(Expressions[0] is LispAtom))
				{
					throw new InvalidOperationException();
				}
				var func = (LispFunction)context[Expressions[0].ToString()];
				try
				{
					return func.Apply(Expressions.Skip(1), context);
				}
				catch (FunctionArityException e)
				{
					throw new AggregateException(string.Format("[{0}] {1}", Position, e.Message), e);
				}
			}
			return this;
		}

		public override string ToString()
		{
			return string.Format("({0})", string.Join(" ", Expressions.Select(a => a.ToString())));
		}
	}
}