using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	public class LispList : LispExpression
	{
		private readonly LispExpression[] _expressions;

		public LispList(IEnumerable<LispExpression> expressions)
		{
			_expressions = expressions.ToArray();
		}

		public override string ToString()
		{
			return string.Format("({0})", string.Join(" ", _expressions.Select(a => a.ToString())));
		}

		public override LispExpression Reduce(LispContext context)
		{
			if (_expressions.Length > 0)
			{
				if (!(_expressions[0] is LispAtom))
				{
					throw new InvalidOperationException();
				}
				var func = context.GetFunction(_expressions[0].ToString());
				return func.Apply(_expressions.Skip(1));
			}
			return this;
		}
	}
}
