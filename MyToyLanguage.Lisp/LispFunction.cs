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
	}
}
