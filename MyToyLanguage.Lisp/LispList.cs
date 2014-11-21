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
	}
}
