using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	public class LispList : LispExpression
	{
		protected readonly LispExpression[] Expressions;

		public LispList(IEnumerable<LispExpression> expressions)
		{
			Expressions = expressions.ToArray();
		}

		public override string ToString()
		{
			return string.Format("({0})", string.Join(" ", Expressions.Select(a => a.ToString())));
		}

		public override LispExpression Reduce(LispContext context)
		{
			if (Expressions.Length > 0)
			{
				if (!(Expressions[0] is LispAtom))
				{
					throw new InvalidOperationException();
				}
				var func = context.GetFunction(Expressions[0].ToString());
				return func.Apply(Expressions.Skip(1), context);
			}
			return this;
		}
	}
}
